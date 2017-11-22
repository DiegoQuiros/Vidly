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

        [Required]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }

        [Required]
        [DisplayFormat(DataFormatString ="{0:dddd, MMMM dd, yyyy}")]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [DisplayFormat(DataFormatString ="{0:dddd, MMMM dd, yyyy}")]
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Required(ErrorMessage = "The field 'Number In Stock' must be between 1 and 20.")]
        [Range(1,20, ErrorMessage = "The field 'Number In Stock' must be between 1 and 20.")]
        [Display(Name = "Number in Stock")]
        public byte NumberInStock { get; set; }
    }
}