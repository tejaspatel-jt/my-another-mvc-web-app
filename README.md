# my-another-mvc-web-app

## 25feb25_107pm - Adding Roles and role based authentication
- added new endpoint `api/Auth/admin-only` into `AuthController`.
```
        [Authorize(Roles = "Admin")]
        [HttpGet("admin-only")]
        public IActionResult AdminOnlyEndPoint()
        {
            return Ok("You are an ADMIN now..... ");
        }
```
- Added new property `Role` to `User` model.
    - Run migration using command....
        - `add-migration "Add User Role" -context UserDbContext`
    - updated database using command ....
        - `update-database -context UserDbContext`
- Manually added role `Admin` to the user which we can use for logging in        
- new claim added to `CreateToken` fun of `AuthService`.
```
new Claim(ClaimTypes.Role, user.Role)
```


## 25feb25_1234pm - Securing Endpoints & adding authentication service
- it can be done using `[Authorize]` attrribute
- added new package `Microsoft.AspNetCore.Authentication.JwtBearer` with version `7.0.3` and changed the version of `System.IdentityModel.Tokens.Jwt` to `7.0.3` for compatibility.
- Added authentication service to `Program.cs` like below
```
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["AppSettings:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["AppSettings:Audience"],
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Token"]!)),
            ValidateIssuerSigningKey = true
        };
    });
```


## 24feb25_621pm - Refactroing with Service Layer
- create class and interface for auth service and added code from controller to class `AuthService` which is implementing `AuthService`.
- ran migrations again after deleting `UserDb` from SSMS as some mess happened :).


## 24feb25_550pm - Create JWT token
- install package `System.IdentityModel.Tokens.Jwt`.
- code first migration done again with guid
- jwt toekn generated.
- 
## 24feb25_136pm - swagger on app's root url
- swagger is configured to To serve the Swagger UI at the app's root on `https://localhost:7211/`
- returned success as token in `login` endpoint.

## 24feb25_1237pm - UserDbContext Migration and api not being hit issue solved
- created `UserDbContext` with primary constructor and added dummy data for seeding with `OnModelCreating` method.
- Done data migration for new User DB and resolved migration errror as having multiple db context within same project.
- configured connection string for `UserDb` in `appsettings.json` file.
- 📌Note :
    - make sure you have `modelBuilder.Entity<User>().HasKey(u => u.Username);` if your model class dont have primary key before running migration.

- `add-migration initial_users_data_seeding -context UserDbContext`
- `update database -context UserDbContext`
- completed register and login endpoint for Auth Controller.
- added below line in `Program.cs` file to solve my api controller is not being hit from swagger
```
app.MapControllers();
```

## 21feb25 - Configured Swagger Support in dotnet 8
actually swagger in this project is messed up as i have used this project for MVC stuff too. :(
- added `Swashbuckle.AspNetCore` nuget package by
```
dotnet add package Swashbuckle.AspNetCore
```
- added below thing in `Program.cs` file
```
builder.Services.AddSwaggerGen();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
```
--------------

# 19feb25 - Create and Connect Database in ASP.NET : [YouTube : tutorialsEU - C#](https://youtu.be/ZX12X-ALwGA?si=vb9DmVcJg6-6t21G)

## Step 1 : Create a new ASP.NET MVC project
- Open Visual Studio > File > New > Project > Select `ASP.NET Core Web App`. > Next > Give Project Name > Next > Choose `net8.0` Framework > Create 🚀.

## Step 2: Install the EF Core packages
Added below Nuget Packages.
1. Microsoft.EntityFrameworkCore
2. Microsoft.EntityFrameworkCore.Tools
3. Microsoft.EntityFrameworkCore.SqlServer

## Step 3: Create a model class 
- Create a model class `Student` under folder Models
```csharp
namespace my_another_mvc_web_app.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime EnrollmentDate { get; set; }
    }
}

```
## Step 4: Create a context class
- Create a context class `SchoolContext` for DbContext (It is responsible for connecting to the database and managing the entities)

```csharp
using Microsoft.EntityFrameworkCore;

namespace my_another_mvc_web_app.Models
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public SchoolContext(DbContextOptions options) : base(options)
        {

        }
    }

}
```

## Step 5: Getting your Database Connection string
```
   "Server=(local);Database=SchoolDB;Trusted_Connection=True;TrustCertificate=True;"
```

## Step 6: Configuring a database provider
- Configure the Database Provider in `Program.cs` file by adding service for the same before the app builds (`var app = builder.Build();`).
```csharp

builder.Services.AddDbContext<SchoolContext>(options => 
{
    options.UseSqlServer("Server=(local);Database=SchoolDB;Trusted_Connection=True;TrustServerCertificate=True");
}
);


```
## Step 7: Use migrations to create the database
- Go to `Tools > Nuget Package Manager > Package Manager Console`.
    - Run Migrations with below command, This command is used to create a new migration file that contains the changes to your database schema based on the current state of your data model.
        ```
        add-migration “InitialDbSeup”
        ```
## Step 8: Update the database
- Now to Apply the pending migrations to the database, effectively updating the database schema to match the current model as defined by your migrations.
    ```
    update-database
    ```

### Your database is created under `Databases` tree of `Microsoft SQL Server Mgmt Studio`.

# 6dec24
- created first sample API with get,post,put,delete operations.

# Exciting New Web API Project 🚀

Welcome to my GitHub repository! I'm thrilled to share my first web API project with you. This journey has been incredibly rewarding, and I can't wait to take it to the next level.

In this project, I've implemented a robust API that allows users to interact with data seamlessly. I've followed an insightful YouTube tutorial that guided me through the process step-by-step. You can check it out here: [YouTube Tutorial](https://www.youtube.com/watch?v=BfuOUso-W_M).

## Key Features:
- **RESTful API Design:** I've adhered to REST principles to ensure a clean and efficient API structure.
- **Dynamic Data Handling:** The API is designed to handle various data requests and responses effectively.
- **Documentation:** I've included comprehensive documentation to help users understand how to utilize the API.

I’m eager to receive feedback and suggestions for improvements. Let’s collaborate and make this project even better together! Happy coding!

# ⚠️⚠️choose github account prompt issue ⚠️⚠️
- due to Multi git account on machine it asks to choose github account to push from/to resolved by setting remote url to specific git
```
git remote set-url origin https://tejaspatel-jt@github.com/tejaspatel-jt/my-another-mvc-web-app
```