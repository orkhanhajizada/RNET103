sudo chmod +x setup.sh

PROJECT_NAME=${1:-$(
  read -p "Proje adı girilmedi. Lütfen bir proje adı girin: " REPLY
  echo $REPLY
)}

# Eğer proje adı hala boşsa, scripti sonlandır
if [ -z "$PROJECT_NAME" ]; then
  echo "Proje adı girilmedi. Script sonlandırılıyor."
  exit 1
fi

# mac için :)
# sudo chmod +x setup.sh
# winget install jqlang.jq
brew install jq
dotnet tool update --global dotnet-ef

# dotnet new webapi -n CategoryApi
dotnet new webapi --use-controllers -o "$PROJECT_NAME"
cd "$PROJECT_NAME"

dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package StackExchange.Redis
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools

dotnet build
dotnet restore

mkdir Data Models

# Models klasörü içerisine Category.cs dosyası eklenmesi

cat >'Models/Category.cs' <<EOF
namespace "$PROJECT_NAME".Models; 
public class Category
{
    public int CategoryID { get; set; }
    public string CategoryName { get; set; } = null!;
    public string? Description { get; set; }
}
EOF

# Data klasörü içerisine ApplicationDbContext.cs dosyası eklenmesi
cat >'Data/ApplicationDbContext.cs' <<EOF
namespace "$PROJECT_NAME".Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options) { }
        public DbSet<Category> Categories { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Beverages", Description = "Soft drinks, coffees, teas, beers, and ales" },
                new Category { CategoryID = 2, CategoryName = "Condiments", Description = "Sweet and savory sauces, relishes, spreads, and seasonings" },
                new Category { CategoryID = 3, CategoryName = "Confections", Description = "Desserts, candies, and sweet breads" },
                new Category { CategoryID = 4, CategoryName = "Dairy Products", Description = "Cheeses" },
                new Category { CategoryID = 5, CategoryName = "Grains/Cereals", Description = "Breads, crackers, pasta, and cereal" },
                new Category { CategoryID = 6, CategoryName = "Meat/Poultry", Description = "Prepared meats" },
                new Category { CategoryID = 7, CategoryName = "Produce", Description = "Dried fruit and bean curd" },
                new Category { CategoryID = 8, CategoryName = "Seafood", Description = "Seaweed and fish" }
            );
 
            base.OnModelCreating(modelBuilder);
        }
    }
}

EOF

# appsetting.json dosyasının değişiklikleri
APPSETTINGS_FILE="appsettings.json"
NEW_JSON=$(jq '. + {
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "docker": "server=code.db;database=codedb;user id=sa;password=Pro247!!;TrustServerCertificate=True;Connection Timeout=30;",
    "default": "server=localhost;database=codedb;user id=sa;password=Pro247!!;TrustServerCertificate=True;Connection Timeout=30;"
  }
}' $APPSETTINGS_FILE)

echo "$NEW_JSON" >$APPSETTINGS_FILE

cat >'GlobalUsings.cs' <<EOF
global using "$PROJECT_NAME".Data;
global using "$PROJECT_NAME".Models;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Design;
global using Microsoft.EntityFrameworkCore.SqlServer;
EOF

# program.cs dosyasının değişiklikleri
PROGRAM_CS_FILE="Program.cs"

# program.cs dosyasının içeriğini bir değişkene atayın
PROGRAM_CS_CONTENT=$(cat $PROGRAM_CS_FILE)

DBCONTEXT_CONFIG="builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString(\""default\""));
});"

UPDATED_PROGRAM_CS_CONTENT="${PROGRAM_CS_CONTENT/builder.Services.AddSwaggerGen();/$DBCONTEXT_CONFIG}"

echo "$UPDATED_PROGRAM_CS_CONTENT" >$PROGRAM_CS_FILE

cd ..

containers=("code.db" "code.rabbitmq" "code.redis")

for container in "${containers[@]}"; do
  CONTAINER_ID=$(docker ps -aqf "name=^${container}$")

  if [ -z "$CONTAINER_ID" ]; then
    echo "Konteyner bulunamadı: $container"
  else
    echo "Konteyner bulundu: $container. Durduruluyor..."
    docker stop $CONTAINER_ID
    docker rm $CONTAINER_ID
    echo "Konteyner durduruldu: $container"
  fi
done
docker network rm code-network

docker builder prune -f
docker-compose up -d

cd "$PROJECT_NAME"
dotnet ef migrations add InitialCreate
dotnet ef database update

dotnet aspnet-codegenerator controller -name CategoriesController -async -api -m Category -dc ApplicationDbContext -outDir Controllers

cd "$PROJECT_NAME"
dotnet watch run
