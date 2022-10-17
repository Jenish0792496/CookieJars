﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;




namespace MvcCookieJars.Models
{
    public class Cookie
    {
        public int Id { get; set; }
        public string CookieName { get; set; }
        public string MainIngredents { get; set; }

        [Display(Name = "First Made Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Pieces { get; set; }
        public decimal Price { get; set; }

        public int Rating { get; set; }

    }
}
