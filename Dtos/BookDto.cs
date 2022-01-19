using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Libly.Models;

namespace Libly.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime? PublishDate { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Range(1, 20)]
        public byte NumberInStock { get; set; }
        public GenreDto Genre { get; set; }
        [Required]
        public byte GenreId { get; set; }
    }
}