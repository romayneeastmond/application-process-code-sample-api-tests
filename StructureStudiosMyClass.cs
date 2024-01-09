// Source: https://github.com/romayneeastmond/application-process-code-sample-api-tests

using System;
using System.IO;
using System.Linq;

public class Statistic
{
    public string Name { get; set; }

    public DateTime Created { get; set; }

    public DateTime Modified { get; set; }
}

public class MyClass
{
    public const string PathToSource = @"C:\Temp\structure-studios-angular\api-test";

    public void Something_Interesting()
    {
        Console.WriteLine($"Performance Review.");
        Console.WriteLine($"Determined by analyzing the test files creation and modified times.{Environment.NewLine}");

        var statistics = GetStatistics();

        GetPerformanceReview(statistics);
    }

    public void GetPerformanceReview(List<Statistic> statistics)
    {
        if (statistics == null || (statistics != null && !statistics.Any()))
        {
            // TODO: Improve logic by throwing an exception and / or including logging.

            Console.WriteLine("Not enough information to perform review.");

            return;
        }

        statistics = statistics.OrderBy(x => x.Created).ToList();

        var performance = statistics.Select(x => new
        {
            Name = x.Name,
            TimeSpent = (TimeSpan)(x.Modified - x.Created)
        }).ToList();

        Console.WriteLine(performance.Select(x => $"{x.Name} => {x.TimeSpent.ToFormattedString()}").ToList().ToCsvString(Environment.NewLine));

        Console.Write($"{Environment.NewLine}Based on time spent, it can be inferred that \"");
        Console.Write(statistics.OrderByDescending(x => x.Modified - x.Created).Take(1).Select(x => x.Name).FirstOrDefault());
        Console.WriteLine("\" took the longest to complete.");

        Console.Write($"{Environment.NewLine}Total time spent was approximately ");
        Console.Write(TimeSpan.FromMilliseconds(performance.Sum(x => x.TimeSpent.TotalMilliseconds)).ToFormattedString());
        Console.WriteLine(".");
    }

    public List<Statistic> GetStatistics()
    {
        var statistics = new List<Statistic>();

        if (Directory.Exists(PathToSource))
        {
            var files = Directory.GetFiles(PathToSource, "*.http");

            if (files.Length > 0)
            {
                foreach (var file in files)
                {
                    var fileInfo = new FileInfo(file);

                    statistics.Add(new Statistic
                    {
                        Name = fileInfo.Name,
                        Created = fileInfo.CreationTimeUtc,
                        Modified = fileInfo.LastWriteTimeUtc
                    });
                }
            }
            else
            {
                Console.WriteLine("No files with extension .http were found.");

                // TODO: Improve logic by throwing an exception and / or including logging.
            }
        }
        else
        {
            Console.WriteLine($"{PathToSource} does not exist.");

            // TODO: Improve logic by throwing an exception and / or including logging.
        }

        return statistics;
    }
}

public static class MyClassExtensions
{
    // TODO: BUG - Since this formats the difference between 2 TimeSpan is makes a faulty assumption that they cannot be the same
    // Using 1 minute as a default instead of 0 minutes can be considered problematic.

    public static string ToFormattedString(this TimeSpan value)
    {
        if (value == null)
        {
            return "1 minute";
        }

        if (value.Days > 0)
        {
            return $"{value.Days} day{(value.Days == 1 ? "" : "s")} yikes!";
        }

        if (value.Hours == 0 && value.Minutes == 0)
        {
            return "1 minute";
        }

        if (value.Hours == 0 && value.Minutes > 0)
        {
            return $"{value.Minutes} minute{(value.Minutes == 1 ? "" : "s")}";
        }

        if (value.Hours > 0 && value.Minutes > 0)
        {
            return $"{value.Hours} hour{(value.Hours == 1 ? "" : "s")} and {value.Minutes} minute{(value.Minutes == 1 ? "" : "s")}";
        }

        return "1 minute";
    }

    /// <summary>
    /// Refactor of StringatizeDemNums.
    /// </summary>	
    /// <param name="delimiter">Optional paramater, that uses comma seperation by default</param>
    /// <returns>A seperated string of the values</returns>
    public static string ToCsvString(this List<string> values, string delimiter = ", ")
    {
        if (values == null || (values != null && !values.Any()))
        {
            return string.Empty;
        }

        return string.Join(delimiter, values);
    }
}