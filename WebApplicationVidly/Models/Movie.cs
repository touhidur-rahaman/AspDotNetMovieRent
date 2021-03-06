﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationVidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        
        public Genre Genre { get; internal set; }

        [Display(Name="Genre")]
        [Required]
        public byte GenreId { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name="Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name="Number In Stock")]
        [Range(1,100)]
        public byte NumberInStock { get; set; }

    }
}