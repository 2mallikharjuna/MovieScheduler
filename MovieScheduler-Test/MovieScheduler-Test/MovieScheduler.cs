using System;
using System.Collections.Generic;
using System.Linq;

public class MovieScheduler
{
    List<Movie> movies = new List<Movie>();
	public void AddMovies(Movie[] Movies)
    {
        foreach(var movie in Movies)
        {
            if (Movies.Any(m => m.CollidesWith(movie)))
            {
                throw new ArgumentException("Invalid movie");
            }
            else
            {
                movies.Add(movie);
                Console.WriteLine("Add meeting: {0} ", movie);
            }
        }
    }
    public List<Movie> getMovies()
    {
        return movies;
    }
}
