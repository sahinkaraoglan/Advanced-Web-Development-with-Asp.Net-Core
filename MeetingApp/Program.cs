var builder = WebApplication.CreateBuilder(args);

//mvc yapısının projeye dahil edilmesi
builder.Services.AddControllersWithViews();

var app = builder.Build();

//wwwroot gibi static dosyaları dışarı açıyoruz.
app.UseStaticFiles();


app.UseRouting();

//app.MapDefaultControllerRoute();
app.MapControllerRoute(
    name:"default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
