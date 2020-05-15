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
            IBook book = new DiskBook("David");
            book.GradeAdded += OnGradeAdded;

            // BREAKS BC delegate can only be assigned with += or -=
            // book.GradeAdded = null;

            EnterGrades(book);

            var stats = book.GetStatistics();
            Console.WriteLine(stats);

        }

        private static void EnterGrades(IBook book)
        {
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
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine($"A Grade was added. {e}");
        }
    }
}

// PILLARS of OOP
// Encapsulation - controls who has access to what
// Inheritance - allows you to reused code across similar classes
// Polymorphism - allows us to have objs of the same type that behave differently