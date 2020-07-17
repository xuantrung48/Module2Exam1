using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public interface IClassRepository
    {
        IEnumerable<Class> Get();
        Class Get(int id);
    }
}
