using AutoMapper;
using MoviesRentalStore.Dtos;
using MoviesRentalStore.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MoviesRentalStore.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private readonly ApplicationDbContext _context;
        private readonly Mapper _mapper;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
            _mapper = new Mapper(MvcApplication._config);
        }

        // GET: api/Movies
        [HttpGet]
        public IEnumerable<MovieDto> GetAllMovies(string query = null)
        {
            var moviesQuery = _context.Movies
                   .Include(m => m.Genre)
                   .Where(m => m.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));

            return moviesQuery
                   .ToList()
                   .Select(_mapper.Map<Movie, MovieDto>);
        }

        // GET: api/Movies/5
        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(_mapper.Map<Movie, MovieDto>(movie));
        }

        // POST: api/Movies
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = _mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movieDto.Id), movie);
        }

        // PUT: api/Movies/5
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDB = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDB == null)
                return NotFound();

            _mapper.Map<MovieDto, Movie>(movieDto, movieInDB);

            //movieInDB.Name = movie.Name;
            //movieInDB.GenreId = movie.GenreId;
            //movieInDB.ReleaseDate = movie.ReleaseDate;
            //movieInDB.NumberInStock = movie.NumberInStock;
            //movieInDB.NumberAvailable = movie.NumberAvailable;

            _context.SaveChanges();

            return Ok(movieInDB);//à vérifier
        }

        // DELETE: api/Movies/5
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDB = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movieInDB);
            _context.SaveChanges();

            return Ok(movieInDB);

        }
    }
}
