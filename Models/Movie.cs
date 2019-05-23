using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace solo.Models
    {
    public class Movie
        {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }
        public short NumberInStock { get; set; }
        public Genres Genres { get; set; }
        [Display(Name = "Genre Type")]
        public byte GenreId { get; set; }
        }
    ////movies/random
    //movies = controllwer;
    //    random = Action;
    }