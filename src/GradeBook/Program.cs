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
        // What is the static keyword?
        // The static keyword negates some of the benefits of object oriented programming by violating rules of encapsulation if used improperly
        static void Main(string[] args)
        {
            var book = new Book("David");
            book.AddGrade(53.4);
            book.AddGrade(90.4);
            book.AddGrade(79.4);
            book.AddGrade(80.4);
            book.AddGrade(-50.3);
            var stats = book.GetStatistics();
            book.ShowStatistics();
            System.Console.WriteLine($"The letter is {stats.Letter}");
        }
    }
}
