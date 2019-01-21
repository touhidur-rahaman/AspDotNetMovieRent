using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplicationVidly.Models;

namespace WebApplicationVidly.ViewModels
{
    public class MovieFormViewModel
    {
        private Movie movie;

        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            GenreId = movie.GenreId;
            NumberInStock = movie.NumberInStock;
        }

        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name ="Genre")]
        [Required]
        public byte? GenreId { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Range(1, 100)]
        [Display(Name = "Number in Stock")]
        public byte? NumberInStock { get; set; }

        public string Title
        {
            get
            {
                if (Id != 0)
                {
                    return "Edit Movie";
                }
                else
                {
                    return "New Movie";
                }
            }
        }


    }
}