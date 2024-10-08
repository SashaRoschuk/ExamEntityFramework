﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamEntityFramework.Entities
{
    public class Publisher
    {
        
        public int ID { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }


        public ICollection<Book>   Books { get; set; }


    }
}
