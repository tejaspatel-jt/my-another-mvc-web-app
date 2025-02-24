using Microsoft.EntityFrameworkCore;
using my_another_mvc_web_app.Models;
using Scalar.AspNetCore;
using Microsoft.OpenApi.Models;
using my_another_mvc_web_app.Data;
using my_another_mvc_web_app.Services; // Add this using directive

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

/* tejas - START */

//builder.Services.AddOpenApi(); // won't work as its only compatible with .net 9+
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<SchoolContext>(options => {
//    // Working for School DB
//    options.UseSqlServer("Server=(local);Database=SchoolDB;Trusted_Connection=True;TrustServerCertificate=True");
//});

builder.Services.AddDbContext<UserDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserDatabase"));
});

builder.Services.AddScoped<IAuthService, AuthService>();

/* tejas - END */

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

    //app.MapScalarApiReference();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}"
//    );

app.Run();
