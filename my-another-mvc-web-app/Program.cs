using Microsoft.EntityFrameworkCore;
using my_another_mvc_web_app.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

/*tejas - start*/

builder.Services.AddDbContext<SchoolContext>(options => 
{
    //options.UseSqlServer(builder.Configuration.GetConnectionString("MvcSchoolContext"))
    //options.UseSqlServer("Server=localhost;Database=MvcSchoolContext;User Id=sa;Password=Password123;")
    options.UseSqlServer("Server=(local);Database=SchoolDB;Trusted_Connection=True;TrustServerCertificate=True");
}
);

/*tejas - end*/

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
