using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationVidly.Models
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }


        public Genre Genre { get; internal set; }
        
        [Required]
        public byte GenreId { get; set; }

        public DateTime DateAdded { get; set; }
        
        public DateTime ReleaseDate { get; set; }

        [Range(1, 100)]
        public byte NumberInStock { get; set; }

    }
}