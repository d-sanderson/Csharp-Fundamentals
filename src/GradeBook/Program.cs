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
            Book book2 = new Book();
            book.AddGrade(89.3);
            book2.AddGrade(43.4);
            book2.AddGrade(90.4);
            book2.AddGrade(79.4);
            book2.AddGrade(80.4);
            book2.GetGradeAverage();
        }
    }
}
