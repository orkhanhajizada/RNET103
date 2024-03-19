using System.Reflection;
using Microsoft.OpenApi.Any;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(opt =>
{

    opt.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Clean Architecture WebApi",
        Version = "v1",
        Description = "<h1>It is a long established</h1> fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here'",
        TermsOfService = new Uri("https://www.google.com"),
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Murat Vuranok",
            Email = "murat.vuranok@code.edu.az",
            Url = new Uri("https://www.muratvuranok.com"),
            Extensions = {
                ["Company"] = new  OpenApiObject() {
                    ["Name"] = new OpenApiString("Code Academy"),
                    ["Url"]  = new OpenApiString("https://www.code.edu.az")
                }
              }
        },
        License = new Microsoft.OpenApi.Models.OpenApiLicense
        {
            Name = "Use under CodeAcademy License",
            Url = new Uri("https://www.google.com")
        }
    });
    opt.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
        $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    // app.UseSwaggerUI();

         app.UseSwaggerUI(c =>
        {
           c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            
            // Swagger UI için bazı opsiyonel yapılandırmalar
            c.RoutePrefix = "docs"; // Swagger UI'nin erişileceği URL yolunu değiştirir (varsayılan: 'swagger')
            c.DocumentTitle = "My API Documentation"; // Tarayıcı sekmesinde görünen başlık
            c.DefaultModelExpandDepth(2); // Model detaylarının varsayılan genişletme derinliği
            c.DefaultModelRendering(Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Model); // Modeli nasıl render ettiği
            c.DefaultModelsExpandDepth(-1); // Model şemalarının genişletme derinliği (-1 hepsini kapalı tutar)
            c.DisplayOperationId(); // Operasyon ID'lerini göster
            c.DisplayRequestDuration(); // İstek süresini göster
            c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None); // Tüm operasyonları varsayılan olarak daraltır
            c.EnableDeepLinking(); // Derin bağlantılara izin ver
            c.EnableFilter(); // Arama filtresini etkinleştir
        });
}

app.UseAuthorization();
app.MapControllers();
app.Run();
