using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class ClassRepository : IClassRepository
    {
        private readonly AppDbContext context;
        public ClassRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Class> Get()
        {
            return context.Classes;
        }

        public Class Get(int id)
        {
            return context.Classes.Find(id);
        }
    }
}
