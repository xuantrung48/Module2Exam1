using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext context;
        public StudentRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Student Create(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
            return student;
        }

        public Student Edit(Student student)
        {
            var editStudent = context.Students.Attach(student);
            editStudent.State = EntityState.Modified;
            context.SaveChanges();
            return student;

        }

        public IEnumerable<Student> Get()
        {
            return context.Students;
        }

        public Student Get(int id)
        {
            return context.Students.Find(id);
        }

        public bool Remove(int id)
        {
            var student = Get(id);
            if (student != null)
            {
                context.Students.Remove(student);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
