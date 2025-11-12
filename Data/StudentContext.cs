using Student.Models;
using Microsoft.EntityFrameworkCore;

namespace Student.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options)
            : base(options) { }

        public DbSet<StudentEntity> Students { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentEntity>().HasData(
                new StudentEntity
                {
                    StudentId = 1,
                    FirstName = "Patrick",
                    LastName = "Guevarra",
                    Birthday = new DateTime(2004, 3, 17),
                    Email = "j.guevarra@student.fdu.edu",
                    Major = "Computer Science",
                    GPA = 3.8,
                    EnrollmentDate = new DateTime(2022, 8, 29)
                }
            );
        }
        
    }
}

