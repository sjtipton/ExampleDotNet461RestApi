using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using ExampleDotNet461RestApi.Models;

namespace ExampleDotNet461RestApi.Controllers
{
    [RoutePrefix("api/movies")]
    public class MoviesController : ApiController
    {
        readonly Movie[] movies = new Movie[]
        {
            new Movie { Id = 1, Title = "Dumb and Dumber", Description = "The cross-country adventures of two good-hearted but incredibly stupid friends.", Year = 1994, Rating = "PG-13" },
            new Movie { Id = 2, Title = "One Crazy Summer", Description = "An aspiring teenage cartoonist and his friends come to the aid of a singer trying to save her family property from developers.", Year = 1986, Rating = "PG" },
            new Movie { Id = 3, Title = "Police Academy 4: Citizens on Patrol", Description = "The misfit Police Academy graduates now are assigned to train a group of civilian volunteers to fight crime once again plaguing the streets.", Year = 1987, Rating = "PG" },
            new Movie { Id = 4, Title = "Rocky 4", Description = "After iron man Drago a highly intimidating 6-foot-5 261-pound Soviet athlete kills Apollo Creed in an exhibition match Rocky comes to the heart of Russia for 15 pile-driving boxing rounds of revenge.", Year = 1985, Rating = "PG" },
            new Movie { Id = 5, Title = "Old School", Description = "Three friends attempt to recapture their glory days by opening up a fraternity near their alma mater.", Year = 2003, Rating = "R" },
            new Movie { Id = 6, Title = "Grease", Description = "Good girl Sandy and greaser Danny fell in love over the summer. When they unexpectedly discover they're now in the same high school will they be able to rekindle their romance?", Year = 1978, Rating = "PG-13" },
            new Movie { Id = 7, Title = "A Christmas Story", Description = "In the 1940s a young boy named Ralphie attempts to convince his parents his teacher and Santa that a Red Ryder BB gun really is the perfect Christmas gift.", Year = 1983, Rating = "PG" },
            new Movie { Id = 8, Title = "Joe Dirt", Description = "After being abandoned by his parents at the Grand Canyon Joe Dirt tells the story of his journey to find his parents.", Year = 2001, Rating = "PG-13" },
            new Movie { Id = 9, Title = "Super Troopers", Description = "Five Vermont state troopers avid pranksters with a knack for screwing up try to save their jobs and out-do the local police department by solving a crime.", Year = 2001, Rating = "R" },
            new Movie { Id = 10, Title = "Days of Thunder", Description = "A young hot-shot stock car driver gets his chance to compete at the top level.", Year = 1990, Rating = "PG-13" }
        };

        // GET api/movies
        [Route("")]
        public IEnumerable<Movie> GetAllMovies()
        {
            return movies;
        }

        // GET api/movies/:id
        [Route("{id:int}")]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = movies.FirstOrDefault((m) => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        // GET api/movies/:rating
        [Route("{rating}")]
        public IEnumerable<Movie> GetMoviesByRating(string rating)
        {
            return movies.Where(m => m.Rating.Equals(rating, StringComparison.OrdinalIgnoreCase));
        }
    }
}