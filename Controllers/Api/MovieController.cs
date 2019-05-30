using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using solo.Models;
using System.Data;
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
            return _DbContext.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
            }
        public IHttpActionResult GetMovie(int id)
            {
           var movie = _DbContext.Movies.Single(m => m.Id == id);
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
        }
    }