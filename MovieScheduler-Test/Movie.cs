using System;
using System.Collections.Generic;

public class Movie : IComparable<Movie>
{
    public Movie(string name, DateTime startTime, DateTime endTime)
    {
        Name = name;
        StartTime = startTime;
        EndTime = endTime;
    }

    public string Name { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public int CompareTo(Movie other)
    {
        // Sort by end time (ascending order)
        return EndTime.CompareTo(other.EndTime);
    }
}

public class MovieScheduler
{
    public static List<Movie> GetMaxMovies(List<Movie> movies)
    {
        // Step 1: Sort movies by EndTime
        movies.Sort();

        List<Movie> result = new List<Movie>();
        DateTime lastEndTime = DateTime.MinValue;

        // Step 2: Select movies greedily
        foreach (var movie in movies)
        {
            if (movie.StartTime >= lastEndTime)
            {
                result.Add(movie);
                lastEndTime = movie.EndTime;
            }
        }

        return result;
    }
}

// Example Usage
public class Program
{
    public static void Main()
    {
        var movies = new List<Movie>
        {
            new Movie("Movie A", DateTime.Parse("2024-11-22T10:00"), DateTime.Parse("2024-11-22T12:00")),
            new Movie("Movie B", DateTime.Parse("2024-11-22T11:00"), DateTime.Parse("2024-11-22T13:00")),
            new Movie("Movie C", DateTime.Parse("2024-11-22T12:30"), DateTime.Parse("2024-11-22T14:00")),
            new Movie("Movie D", DateTime.Parse("2024-11-22T14:00"), DateTime.Parse("2024-11-22T16:00"))
        };

        var schedule = MovieScheduler.GetMaxMovies(movies);

        Console.WriteLine("Movies you can watch:");
        foreach (var movie in schedule)
        {
            Console.WriteLine($"- {movie.Name} ({movie.StartTime} to {movie.EndTime})");
        }
    }
}

