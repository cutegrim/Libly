using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Libly.Models
{
    public class Genre
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}