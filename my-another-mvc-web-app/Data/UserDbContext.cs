using Microsoft.EntityFrameworkCore;
using my_another_mvc_web_app.Entities;

namespace my_another_mvc_web_app.Data
{
    public class UserDbContext(DbContextOptions<UserDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().HasKey(u => u.Username);

        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<User>().HasData(
        //        new User
        //        {
        //            Username = "tejas",
        //            PasswordHash = "1234"
        //        },
        //        new User
        //        {
        //            Username = "rahul",
        //            PasswordHash = "1234"
        //        },
        //        new User
        //        {
        //            Username = "rohit",
        //            PasswordHash = "1234"
        //        },
        //        new User
        //        {
        //            Username = "raju",
        //            PasswordHash = "1234"
        //        },
        //        new User
        //        {
        //            Username = "ravi",
        //            PasswordHash = "1234"
        //        }
        //    );

        //}
    }
}
