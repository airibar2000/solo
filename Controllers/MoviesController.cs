using solo.Models;
using solo.ViewModels;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace solo.Controllers
{
    public class
        MoviesController : Controller
        {
        // conect to database
        // Connect the controller with database
        private readonly MyDBContext _myDb;
        public MoviesController()
            {
            _myDb = new MyDBContext();

            }
        protected override void Dispose(bool disposing)
            {
            _myDb.Dispose();
            }
        // end conect controler with database
        // end connect  to database

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2})}")]
        public ActionResult ByReleaseDate(int year, int month)
            {
            return Content("Year: " + year + " Month:" + month);
            }

        // GET: Movies/Random
        [Route("movies")]
        public ActionResult Index()
            {
            var movies = _myDb.Movies.Include(c => c.Genres).ToList();
            return View(movies);
            }




        public ActionResult Edit(int id)
            {
            return Content("id: " + id);
            }
        //Get : Movies
        public ActionResult Index(int? pageIndex, string sortBy)
            {

            if (!pageIndex.HasValue)
                {
                pageIndex = 1;
                }
            if (string.IsNullOrWhiteSpace(sortBy))
                {
                sortBy = "Name";
                }

            return Content(String.Format("Page Index: {0} and Sort by {1}", pageIndex, sortBy));

            }

        [Route("Movies/Detail/{id}")]
        public ActionResult Detail(int id)
            {

            var MovieDetail = _myDb.Movies.Include(c => c.Genres).SingleOrDefault(c => c.Id == id);
            var MovieDetailWithGenre = new MoviesWithGener
                {
                Movie = MovieDetail,
                Genres = _myDb.Genres.ToList()
                
                
                };
            if (MovieDetail == null)
                {
                return HttpNotFound();
                }
            ViewBag.MovieAction = "Edit Movie";
            return View("NewMovie", MovieDetailWithGenre);
            }

        [Route("Movies/newmovie")]
        public ActionResult NewMovie()
            {
            var listOfgenre = _myDb.Genres.ToList();
            var Movieall = new MoviesWithGener
                {
                Genres = listOfgenre.ToList()
                };
            ViewBag.MovieAction = "New Movie";
            return View(Movieall);
            
            }
        public ActionResult Save(Movie movie)
            {
            if (movie.Id == 0)
                {
                _myDb.Movies.Add(movie);
                }else
                {
                var movieToUpdate = _myDb.Movies.Single(m => m.Id == movie.Id);
                movieToUpdate.Name = movie.Name;
                movieToUpdate.ReleaseDate = movie.ReleaseDate;
                movieToUpdate.NumberInStock = movie.NumberInStock;

                }
            _myDb.SaveChanges();
           return RedirectToAction("index","movies");
            }
        }
    
}
