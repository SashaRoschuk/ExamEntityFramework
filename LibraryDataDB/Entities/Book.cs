using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamEntityFramework.Entities
{

    public class Book
    {

        public int ID { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Istrilogy { get; set; }
        public DateTime PublicationDate { get; set; }
        public int Rating { get; set; }



        public int AuthorID { get; set; }
        public Author Author { get; set; }
        public int PublisherID { get; set; }//fk
        public Publisher Publisher { get; set; }//null

        public int GenreID { get; set; }//FK
        public Genre Genre { get; set; }


    }
}
