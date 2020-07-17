using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public interface IStudentRepository
    {
        IEnumerable<Student> Get();
        Student Get(int id);
        Student Create(Student student);
        Student Edit(Student student);
        bool Remove(int id);
    }
}
