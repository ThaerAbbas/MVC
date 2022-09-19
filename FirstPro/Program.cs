using FirstPro.Data;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();


app.UseSession();
app.MapControllers();


app.MapControllerRoute(name :"Guessing",
      pattern: "GuessingGame/{*GuessGame}",
                defaults: new { controller = "GuessingGame", action = "GuessGame" });

app.MapControllerRoute(
    name: "Person",
          pattern: "Person/{*Person}",
                defaults: new { controller = "Person", action = "Person" });


app.MapControllerRoute(
    name: "City",
          pattern: "City/{*City}",
                defaults: new { controller = "City", action = "City" });



app.MapControllerRoute(name: "Create",
      pattern: "Create/{*Create}",
                defaults: new { controller = "Person", action = "Create" });


app.MapControllerRoute(
    name: "Country",
          pattern: "Country/{*Country}",
                defaults: new { controller = "Country", action = "Country" });



app.MapControllerRoute(
    name: "Language",
          pattern: "Language/{*Language}",
                defaults: new { controller = "Language", action = "Language" });


    app.MapControllerRoute(
    name: "Edit",
        pattern: "Edit/{*Edit}",
                defaults: new { controller = "Person", action = "Edit" });



app.MapControllerRoute(
    name: "Delete",
        pattern: "Delete/{*Delete}",
                defaults: new { controller = "Person", action = "Delete" });

app.MapControllerRoute(name: "CreateLang",
      pattern: "CreateLang/{*CreateLang}",
                defaults: new { controller = "Language", action = "CreateLang" });

app.MapControllerRoute(
    name: "Delete",
        pattern: "DeleteLang/{*DeleteLang}",
                defaults: new { controller = "Language", action = "DeleteLang" });



app.MapControllerRoute(
name: "Edit",
    pattern: "EditLang/{*EditLang}",
            defaults: new { controller = "Language", action = "EditLang" });










app.MapControllerRoute(
    name: "Ajax",
     pattern: "Ajax/{*AjaxIndex}",
                defaults: new { controller = "Ajax", action = "AjaxIndex" });






app.MapControllerRoute(name: "Doctor",
                pattern: "Fever/{*CheckTemp}",
                defaults: new { controller = "Fever", action = "CheckTemp" });
app.MapControllerRoute(name: "default",
               pattern: "{controller=Home}/{action=Index}/{id?}");







app.Run();
