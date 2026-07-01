var builder = WebApplication.CreateBuilder(args);

//mvc yapısının projeye dahil edilmesi
builder.Services.AddControllersWithViews();

var app = builder.Build();

//controller/action/id?
//app.MapDefaultControllerRoute();
app.MapControllerRoute(
    name:"default",
    pattern: "{controller=Meeting}/{action=Index}/{id?}"
);

app.Run();
