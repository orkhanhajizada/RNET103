﻿using BlogApplication.Data;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BlogApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("default") ?? throw new InvalidOperationException("Connection string 'BlogApplicationContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=home}/{action=index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=home}/{action=index}/{id?}");


app.Run();
