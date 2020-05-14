using System;
using System.Collections.Generic;

// C# Training 
// .NET is a runtime, provides a space to run C#, Visual Basic, F#
// CLR (Common Lanaguage runtime)
// FCL (Framework Class Libary) - dotnet provides a library of code that is already tested
// From the cmd line you can run:
// dotnet --info - returns environment info
// dotnet --help - returns a list of helpful commands
// dotnet build - compiles Project Source code into binary. Produces 
// dotnet build will create a bin/obj folders, you can delete these (they will be recreated the next time you run dotnet build)

namespace GradeBook
{
    class Program
    {
        // Main is a method (a function within an object.)
        static void Main(string[] args)
        {
            var book = new Book();
            book.AddGrade(89.3);
            // var (implicit typing) vs using explicity typing string, int, double, byte, etc.
            //Initialize a list
            var grades = new List<double>() { 43.5, 2.5, 31.5 };
            double sum = 0.0;
            foreach (var n in grades)
            {
                sum += n;
            }
            double avg;
            double count = grades.Count;
            avg = sum / grades.Count;
            Console.WriteLine($"The student's average grade is {avg:N2}");
        }
    }
}
