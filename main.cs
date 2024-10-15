using System;

public class Duration
{
    public int Hours { get; set; }
    public int Minutes { get; set; }
    public int Seconds { get; set; }

    // Constructor 1: Initialize with hours, minutes, and seconds
    public Duration(int hours, int minutes, int seconds)
    {
        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;
        Normalize(); // To adjust any overflow from seconds to minutes, or minutes to hours
    }

    // Constructor 2: Initialize with total seconds
    public Duration(int totalSeconds)
    {
        Hours = totalSeconds / 3600;
        Minutes = (totalSeconds % 3600) / 60;
        Seconds = totalSeconds % 60;
        Normalize(); // To handle any normalization if needed
    }

    // Method to return the formatted string
    public string GetString()
    {
        string result = "";

        if (Hours > 0)
            result += $"Hours: {Hours}, ";
        if (Minutes > 0 || Hours > 0) // Only include minutes if there are minutes or hours
            result += $"Minutes: {Minutes}, ";
        result += $"Seconds: {Seconds}";

        return result;
    }

    // Normalize method to handle overflow of seconds and minutes
    private void Normalize()
    {
        if (Seconds >= 60)
        {
            Minutes += Seconds / 60;
            Seconds = Seconds % 60;
        }

        if (Minutes >= 60)
        {
            Hours += Minutes / 60;
            Minutes = Minutes % 60;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Example 1
        Duration D1 = new Duration(1, 10, 15);
        Console.WriteLine(D1.GetString()); // Output: Hours: 1, Minutes: 10, Seconds: 15

        // Example 2
        Duration D2 = new Duration(3600);
        Console.WriteLine(D2.GetString()); // Output: Hours: 1, Minutes: 0, Seconds: 0

        // Example 3
        Duration D3 = new Duration(7800);
        Console.WriteLine(D3.GetString()); // Output: Hours: 2, Minutes: 10, Seconds: 0

        // Example 4
        Duration D4 = new Duration(666);
        Console.WriteLine(D4.GetString()); // Output: Minutes: 11, Seconds: 6
    }
}
