using FirstPro.Data;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity;
using FirstPro.Models;
using FirstPro.Controllers;








var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
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




builder.Services.AddDefaultIdentity<FirstProUser>(options => options.SignIn.RequireConfirmedAccount = false)
 .AddRoles<IdentityRole>()
 .AddEntityFrameworkStores<AppDbContext>();





builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = true;
    options.Password.RequiredUniqueChars = 1;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;

});


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyPolicy",
        policy =>
        {
            policy.WithOrigins("*")
                    .WithMethods("PUT", "DELETE", "GET","POST");
        });
});



builder.Services.AddRazorPages();

var app = builder.Build();

app.UseCors(
        options => options.WithOrigins("https://localhost:7161").AllowAnyMethod()
            );

app.UseCors(MyAllowSpecificOrigins);

app.UseCors(x => x.WithOrigins("http://localhost:3000/NewPerson")

                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true) // allow any origin
                    .AllowCredentials()); // allow credentials


app.UseStaticFiles();


app.UseRouting();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
}); 
app.UseSession();




app.MapRazorPages();

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
    name: "DeleteLang",
        pattern: "DeleteLang/{*DeleteLang}",
                defaults: new { controller = "Language", action = "DeleteLang" });



app.MapControllerRoute(
name: "EditLang",
    pattern: "EditLang/{*EditLang}",
            defaults: new { controller = "Language", action = "EditLang" });


app.MapControllerRoute(
name: "EditCountry",
    pattern: "EditCountry/{*EditCountry}",
            defaults: new { controller = "Country", action = "EditCountry" });





app.MapControllerRoute(
name: "CreateCountry",
    pattern: "CreateCountry/{*CreateCountry}",
            defaults: new { controller = "Country", action = "CreateCountry" });







app.MapControllerRoute(
name: "DeleteCountry",
    pattern: "DeleteCountry/{*DeleteCountry}",
            defaults: new { controller = "Country", action = "DeleteCountry" });





app.MapControllerRoute(
name: "Create",
    pattern: "Create new role/{*Create}",
            defaults: new { controller = "Role", action = "Create" });





app.MapControllerRoute(
name: "ShowAllUsers",
    pattern: "Check users/{*ShowAllUsers}",
            defaults: new { controller = "Role", action = "ShowAllUsers" });





app.MapControllerRoute(
name: "ShowUserRoles",
    pattern: "Check roles /{*ShowUserRoles}",
            defaults: new { controller = "Role", action = "ShowUserRoles" });



app.MapControllerRoute(
name: "ShowRoles",
    pattern: "ShowRoles /{*Index}",
            defaults: new { controller = "Role", action = "Index" });




app.MapControllerRoute(
name: "AddRoleToUser",
    pattern: "AddRoleToUser /{*AddRoleToUser}",
            defaults: new { controller = "Role", action = "AddRoleToUser" });




app.MapControllerRoute(
    name: "Role",
        pattern: "Role/{*Index}",
                defaults: new { controller = "Role", action = "Index" });











app.MapControllerRoute(
    name: "Ajax",
     pattern: "Ajax/{*AjaxIndex}",
                defaults: new { controller = "Ajax", action = "AjaxIndex" });






app.MapControllerRoute(name: "Doctor",
                pattern: "Fever/{*CheckTemp}",
                defaults: new { controller = "Fever", action = "CheckTemp" });
app.MapControllerRoute(name: "default",
               pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseAuthentication();;







app.Run();
