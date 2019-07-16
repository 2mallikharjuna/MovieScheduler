using System;

public class Movie : IComparable<Movie>
{
	public Movie(string name, DateTime startTime, DateTime endTime)
	{

        Name = name;
        StartTime = startTime;
        EndTime = endTime;
	}
    public string Name { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
}
