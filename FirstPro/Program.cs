var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);

});
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();


app.UseSession();



app.MapControllerRoute(

    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "Doctor",
    pattern: "{controller=Fever}/{action=CheckTemp}/{id?}");

app.MapControllerRoute(
    name: "GuessingGame",
    pattern: "{controller=GuessingGame}/{action=GuessGame}/{id?}");

app.MapControllerRoute(
    name: "Person",
    pattern: "{controller=Person}/{action=Person}/{id?}");

app.MapControllerRoute(
    name: "Delete",
    pattern: "{controller=Delete}/{action=Delete}/{id?}");



app.MapControllerRoute(
    name: "Ajax",
    pattern: "{controller=Ajax}/{action=Index}/{Id?}");


app.Run();
