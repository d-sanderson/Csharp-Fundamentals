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
            while (true)
            {
                System.Console.WriteLine("Enter a grade or enter Q to Quit");
                var input = Console.ReadLine();
                if (input == "Q")
                {
                    break;
                }
                // TRY CATCH BLOCK
                // try the code below
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                    System.Console.WriteLine($"{grade} added");
                }
                // Catch ANY type of Exception
                // catch(Exception ex) <- Don't do this in the wild - we don't know what kind of errors will occur here.
                // You want to write catch statements that will ONLY handle EXCEPTIONS that you can HANDLE
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);

                }
                catch (FormatException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                // always execute code, whether it executes succesfully or throws an Exception
                finally
                {
                    Console.WriteLine("runs everytime.");
                }
            }

            var stats = book.ShowStatistics();
            Console.WriteLine(stats);

        }
    }
}
