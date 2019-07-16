using System;

public class Movie 
{
	public Movie(string name, DateTime startTime, DateTime endTime)
	{
        if (startTime < endTime)
        {
            Name = name;
            StartTime = startTime;
            EndTime = endTime;
        }
        else
            throw new ArgumentException("End date should be greater than start date");
	}
    public string Name { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool CollidesWith(Movie other)
    {
        if ((thisEndsWhileOtherIsRunning(other)) || thisBeginsWhileOtherIsRunning(other))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool thisBeginsWhileOtherIsRunning(Movie other)
    {
        return this.StartTime >= other.StartTime && this.StartTime <= other.EndTime;
    }

    private bool thisEndsWhileOtherIsRunning(Movie other)
    {
        return this.EndTime >= other.StartTime && this.EndTime <= other.EndTime;
    }
    
}
