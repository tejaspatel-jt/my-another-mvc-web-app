using Microsoft.EntityFrameworkCore;

namespace my_another_mvc_web_app.Models
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        //public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        //{
        //}

        public SchoolContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    Name = "Tejas",
                    EnrollmentDate = DateTime.Parse("2021-08-01")
                },
                new Student
                {
                    Id = 2,
                    Name = "Rahul",
                    EnrollmentDate = DateTime.Parse("2021-08-01")
                },
                new Student
                {
                    Id = 3,
                    Name = "Rohit",
                    EnrollmentDate = DateTime.Parse("2021-08-01")
                },
                new Student
                {
                    Id = 4,
                    Name = "Raju",
                    EnrollmentDate = DateTime.Parse("2021-08-01")
                },
                new Student
                {
                    Id = 5,
                    Name = "Ravi",
                    EnrollmentDate = DateTime.Parse("2021-08-01")
                }


                );

            //modelBuilder.Entity<Student>().ToTable("Student");
        }
    }

}
