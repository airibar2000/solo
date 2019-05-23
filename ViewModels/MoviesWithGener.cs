using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using solo.Models;
namespace solo.ViewModels
    {
    public class MoviesWithGener
        {
        public Movie Movie { get; set; }
        public List<Genres> Genres { get; set; }
        }
    }