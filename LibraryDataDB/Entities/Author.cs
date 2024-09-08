using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamEntityFramework.Entities
{
    public class Author
    {
        [Key]
        public int ID { get; set; }
        [Required,MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        [Required, MaxLength(50)]
        public string Email { get; set; }
        public string? Phone { get; set; }




        public int CountryID { get; set; }
        public Country Country { get; set; }

        public ICollection<Book> Books { get; set; }



    }
}
