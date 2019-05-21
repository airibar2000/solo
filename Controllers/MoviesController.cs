using solo.Models;
using solo.ViewModels;
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
       [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2})}")]
       public ActionResult ByReleaseDate(int year,int month)
            {
            return Content("Year: " + year + " Month:" + month);
            }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Sherk" };
            var customers = new List<Customer>()
                { new Customer {Name ="Customer 1"},
                  new Customer {Name ="Customer 2"}
                };
            var viewModel = new RandomMovieViewModel
                {
                Movie = movie,
                Customers = customers
                };



            return View(viewModel);
        }
        public ActionResult Edit(int id)
            {
            return Content("id: " + id);
            }
        //Get : Movies
        public ActionResult Index(int? pageIndex,string sortBy)
            {

            if (!pageIndex.HasValue)
                {
                pageIndex = 1;
                }
            if (string.IsNullOrWhiteSpace(sortBy))
                {
                sortBy = "Name";
                }

            return Content(String.Format("Page Index: {0} and Sort by {1}",pageIndex,sortBy));

            }
    }
}