using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovieApi.Models
{
    public static class MovieApiContext
    {
        private static List<Movie> _movies;

        // This is hard-coded now, here the app would connect to a DB
        public static List<Movie> Movies
        {
            get
            {
                if (_movies == null)
                {
                    var movies = new Movie[]
                    {
                        new Movie(1, "The lord of the rings", 2001, "Peter Jackson", new string[] {"Fantasy", "Adventure" }, new string[] { "Elijah Wood","Orlando Bloom" } ),
                        new Movie(2, "The matrix", 1999, "Wachowski Brothers", new string[] { "Sci-Fi", "Fantasy", "Action" }, new string[] { "Keanu Reeves", "Laurence Fishburne" } ),
                        new Movie(3, "Inception", 2010, "Christopher Nolan", new string[] {"Sci-Fi", "Thriller", "Mystery" }, new string[] { "Leonardo Di Caprio", "Joseph Gordon-Levitt" } )
                    };
                    _movies = movies.ToList<Movie>();    
                }
                return _movies;
            }
        }
    }
}
