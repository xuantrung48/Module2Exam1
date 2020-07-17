using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class Class
    {
        [Required]
        public int ClassId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
