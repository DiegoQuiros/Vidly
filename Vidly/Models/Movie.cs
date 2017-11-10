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
        [DisplayFormat(DataFormatString ="{0:dddd, MMMM dd, yyyy}")]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        [DisplayFormat(DataFormatString ="{0:dddd, MMMM dd, yyyy}")]
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }
        public byte NumberInStock { get; set; }
    }
}