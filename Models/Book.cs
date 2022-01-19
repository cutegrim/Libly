using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Libly.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Display(Name = "Date")]
        public DateTime? PublishDate { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Range(1,20)]
        [Display(Name = "Number in Stock")]
        public byte NumberInStock { get; set; }
        public Genre Genre { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }


    }

    // /books/random
}
