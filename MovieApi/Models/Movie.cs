using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MovieApi.Models
{
    // This is a hard coded input for movies, data should be retrieved from a DB connection instead
    //{id:1,name:"The lord of the rings",year:2001,director:"Peter Jackson",genre:["Fantasy","Adventure"],cast:["Elijah Wood","Orlando Bloom"]},
    //{id:2,name:"The matrix",year:1999,director:"Wachowski Brothers",genre:["Sci-Fi", "Fantasy", "Action"],cast:["Keanu Reeves"," Laurence Fishburne"]},
    //{id:3,name:"Inception",year:2010,director:"Cristopher Nolan",genre:["Sci-Fi", "Thriller","Mystery"],cast:["Leonardo Di Caprio"," Joseph Gordon-Levitt"]}

    public class Movie
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string[] Genre { get; set; }
        public string[] Cast { get; set; }

        public Movie(int id, string name, int year, string director, string[] genre, string[] cast)
        {
            Id = id;
            Name = name;
            Year = year;
            Director = director;
            Genre = genre;
            Cast = cast;
        }
    }
}