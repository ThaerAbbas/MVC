var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);

});
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseHttpsRedirection();
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
    name: "Ajax",
     pattern: "Ajax/{*Index}",
                defaults: new { controller = "AjaxPerson", action = "Index" });






app.MapControllerRoute(name: "Doctor",
                pattern: "Fever/{*CheckTemp}",
                defaults: new { controller = "Fever", action = "CheckTemp" });
app.MapControllerRoute(name: "default",
               pattern: "{controller=Home}/{action=Index}/{id?}");







app.Run();
