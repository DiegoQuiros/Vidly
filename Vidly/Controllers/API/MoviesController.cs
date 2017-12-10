using System;
using System.Linq;
using System.Web.Http;
using Vidly.Models;
using Vidly.Models.DTOs;
using AutoMapper;
using System.Data.Entity;
using System.Collections.Generic;

namespace Vidly.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/movies
        public IEnumerable<MovieDTO> GetMovies()
        {
            return _context.Movies
                .Include(m => m.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDTO>);
        }

        // GET /api/movies/1
        public IHttpActionResult GetMovie(int Id)
        {
            Movie movieInDb = _context.Movies.SingleOrDefault(m => m.Id == Id);

            if (movieInDb == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDTO>(movieInDb));
        }

        // POST /api/movies/1
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Movie movie = Mapper.Map<MovieDTO, Movie>(movieDTO);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDTO.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDTO);
        }

        // PUT /api/movies/1
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateMovie(int Id, MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Movie movieInDb = _context.Movies.SingleOrDefault(m => m.Id == Id);

            if (movieInDb == null)
                return NotFound();

            Mapper.Map(movieDTO, movieInDb);
            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/movies/1
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult DeleteMovie(int Id)
        {
            Movie movieInDb = _context.Movies.SingleOrDefault(m => m.Id == Id);

            if (movieInDb == null)
                return NotFound();

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}