using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Genres Genre { get; set; }
        [DisplayFormat(DataFormatString ="0:ddd MMM dd, yyyy")]
        public DateTime ReleaseDate { get; set; }
        [DisplayFormat(DataFormatString ="0:ddd MMM dd, yyyy")]
        public DateTime DateAdded { get; set; }
        public byte NumberInStock { get; set; }
    }
}