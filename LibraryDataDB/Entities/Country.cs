using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamEntityFramework.Entities
{
    public class Country
    {
        
        public int ID { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        public ICollection<Author> Authors { get; set; }

    }
}
