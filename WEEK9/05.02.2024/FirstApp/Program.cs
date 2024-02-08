using FirstApp;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

string message = app.Configuration["Message"];
string message1 = app.Configuration.GetSection("message").Value;
string message2 = app.Configuration.GetValue<string>("message");

var url = app.Configuration["CurrentApplication:Url"];
var port = app.Configuration["CurrentApplication:Port"];
var ssl = app.Configuration["CurrentApplication:Ssl"];
var version = app.Configuration["CurrentApplication:Version"];
var schema = app.Configuration["CurrentApplication:Schema"];
var environment = app.Configuration["CurrentApplication:Environment"];


var applicationSetting = app.Configuration.GetSection("CurrentApplication").Get<CurrentApplication>();

app.MapGet("/",
    () =>
        $"Url: {applicationSetting.Url}, " +
        $"Port: {applicationSetting.Port}, " +
        $"Ssl: {applicationSetting.Ssl}, " +
        $"Version: {applicationSetting.Version}, " +
        $"Schema: {applicationSetting.Schema}, " +
        $"Environment: {applicationSetting.Environment}," +
        $" Message: {message}");

// app.MapGet("/", () => "Hello World!");

app.Run();