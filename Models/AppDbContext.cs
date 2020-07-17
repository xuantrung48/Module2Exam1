using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Class>().HasData(
                new Class()
                {
                    ClassId = 1,
                    Name = "C0120"
                },
                new Class()
                {
                    ClassId = 2,
                    Name = "C0220"
                },
                new Class()
                {
                    ClassId = 3,
                    Name = "C0320"
                });
            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    StudentId = 1,
                    FullName = "Trung",
                    Email = "xuantrung@email.com",
                    ClassId = 1,
                    Dob = DateTime.Parse("17/07/1990"),
                    Gender = Gender.Male
                },
                new Student()
                {
                    StudentId = 2,
                    FullName = "Quang",
                    Email = "quang@email.com",
                    ClassId = 1,
                    Dob = DateTime.Parse("17/07/1991"),
                    Gender = Gender.Male
                },
                new Student()
                {
                    StudentId = 3,
                    FullName = "Minh",
                    Email = "minh@email.com",
                    ClassId = 1,
                    Dob = DateTime.Parse("17/07/1992"),
                    Gender = Gender.Male
                },
                new Student()
                {
                    StudentId = 4,
                    FullName = "Trâm",
                    Email = "tram@email.com",
                    ClassId = 2,
                    Dob = DateTime.Parse("17/07/1993"),
                    Gender = Gender.Female
                },
                new Student()
                {
                    StudentId = 5,
                    FullName = "Ghi",
                    Email = "ghi@email.com",
                    ClassId = 2,
                    Dob = DateTime.Parse("17/07/1994"),
                    Gender = Gender.Female
                });
        }
    }
}
