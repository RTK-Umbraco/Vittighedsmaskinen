var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.UseSession();

app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Joke}/{action=Index}/{id?}");
app.Run();
