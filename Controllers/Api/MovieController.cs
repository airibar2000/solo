using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using solo.Models;
using System.Data;
using System.Data.Entity;
using solo.Dtos;
using AutoMapper;


namespace solo.Controllers.Api
    {
    public class MovieController : ApiController
        {
        // Aceess Data
        private readonly MyDBContext _DbContext;
        public MovieController()
            {
            _DbContext = new MyDBContext();
            }

        // GET api/<controller>
        [HttpGet]
        public IEnumerable<MovieDto> GetMovies()
              {

            var movies =   _DbContext.Movies
                .Include(m => m.Genres)
                .ToList()
                .Select(Mapper.Map<Movie,MovieDto>);

            return movies;
                        }
        public IHttpActionResult GetMovie(int id)
            {
            var movie = _DbContext.Movies.ToList().Single(m => m.Id == id);
            if (movie == null)
                return NotFound();
            return Ok(Mapper.Map<Movie, MovieDto>(movie));
                        }
        [HttpPost]
        public IHttpActionResult PostMovie(MovieDto movieDto)
            {
            if (!ModelState.IsValid)
                {
                return BadRequest();
                }else
                {
                var movie = Mapper.Map<MovieDto, Movie>(movieDto);
                
                _DbContext.Movies.Add(movie);
                _DbContext.SaveChanges();
                movieDto.Id = movie.Id;
                return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
                };
            }
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id,MovieDto movieDto)
            {
            var movieInDb = _DbContext.Movies.Single(m => m.Id == id);
            if (movieInDb == null)
                return NotFound();
            Mapper.Map(movieDto, movieInDb); 
            _DbContext.SaveChanges();
            return Ok();
            }
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
            {
            var movie = _DbContext.Movies.Single(m => m.Id == id);
            if (movie == null)
                return NotFound();
            _DbContext.Movies.Remove(movie);
            _DbContext.SaveChanges();
            return Ok();
            }

        }
    }