using System;
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
        [Column(TypeName = "decimal(18, 2)")]

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

    }
}
