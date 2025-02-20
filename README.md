# my-another-mvc-web-app

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