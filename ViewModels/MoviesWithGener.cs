using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using solo.Models;
using System.ComponentModel.DataAnnotations;
namespace solo.ViewModels
    {
    public class MoviesWithGener
        {

        // Constructors
        public MoviesWithGener(Movie movie)
            {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
            }
        public MoviesWithGener()
            {
            Id = 0;
            }
        // End Constructor

        public IEnumerable<Genres> Genres { get; set; }


        public int? Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name too Long")]
        public string Name { get; set; }

        [Required]
        [ValidationMovie]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Field Number in Stock must be between 1 and 20")]
        public short? NumberInStock { get; set; }


        [Display(Name = "Genre Type")]
        public byte? GenreId { get; set; }

        public string PageTitle
            {
            get
                {
                if (Id != 0) return "Edit Movie";
                return "New Movie";
                }
            set { }

            }
        }
   
    }
    