using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MovieApi.Models;

namespace MovieApi.Controllers
{
    public class MoviesController : ApiController
    {
        private List<Movie> _movies = MovieApiContext.Movies;

        // GET: api/Movies
        public Movie[] GetMovies()
        {
            return _movies.ToArray();
        }

        // GET: api/Movies/5
        [ResponseType(typeof(Movie))]
        public IHttpActionResult GetMovie(int id)
        {
            Movie movie;
            if (MovieExists(id))
            {
                movie = _movies.ElementAtOrDefault(id);
            }
            else
            {
                return NotFound();
            }

            return Ok(movie);
        }

        // PUT: api/Movies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMovie(int id, Movie movie)
        {
            if (MovieExists(id))
            {
                return BadRequest(string.Format("Movie '{0}' cannot be inserted with id '{1}', the id already exists", movie.Name, id));
            }

            if (id != movie.Id)
            {
                return BadRequest("Id provided does not match id attribute for movie");
            }

            _movies.Add(movie);

            return StatusCode(HttpStatusCode.OK);
        }

        // POST: api/Movies
        [ResponseType(typeof(Movie))]
        public IHttpActionResult PostMovie(Movie movie)
        {
            if (MovieExists(movie.Id))
            {
                return BadRequest(string.Format("Movie with id: {0} already exists", movie.Id));
            }

            _movies.Add(movie);
            
            return CreatedAtRoute("DefaultApi", new { id = movie.Id }, movie);
        }

        // DELETE: api/Movies/5
        [ResponseType(typeof(Movie))]
        public IHttpActionResult DeleteMovie(int id)
        {
            if (!MovieExists(id))
            {
                return NotFound();
            }

            Movie movie = _movies.ElementAt(id);
            _movies.RemoveAt(id);

            return Ok(movie);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        private bool MovieExists(int id)
        {
            return _movies.Count(x => x.Id == id) > 0;
        }
    }
}