using CodeFirstApp.Cryptography;
using CodeFirstApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstApp.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Tenant> Tenants { get; set; }
}

public class ApplicationDbContextFactory
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IConfiguration _configuration;
    private readonly ICryptographyService _cryptographyService;
    private readonly ApplicationDbContext _applicationDbContext;
    
    public ApplicationDbContextFactory(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, ICryptographyService cryptographyService, ApplicationDbContext applicationDbContext)
    {
        _httpContextAccessor = httpContextAccessor;
        _configuration = configuration;
        _cryptographyService = cryptographyService;
        _applicationDbContext = applicationDbContext;
    }
    
    public ApplicationDbContext CreateContext()
    {
        var tenantId = _httpContextAccessor.HttpContext!.Request.Headers["Tenant-Id"].FirstOrDefault();
        
        if(string.IsNullOrWhiteSpace(tenantId))
            throw new Exception("Tenant-Id header is required");
        
        var tenant = _applicationDbContext.Tenants.FirstOrDefault(x => x.TenantId == int.Parse(tenantId));
        
        if(tenant == null)
            throw new Exception("Tenant not found");
        
        var connectionString = _cryptographyService.Decrypt(tenant.ConnectionString, tenant.TenancyName);
        
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer(connectionString);
        
        return new ApplicationDbContext(optionsBuilder.Options);
    }
}