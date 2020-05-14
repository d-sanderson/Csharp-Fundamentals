using System;
using System.Collections.Generic;

// UNIT Testing 
// Write code that tests edge cases and common input to make sure your code is working working as intended.
// We use a testrunner to run unit tests. xUnit.net is a test runner we will be using in this course
namespace GradeBook
{
    public class Book
    {
        //Write an explicit constructor if a constructor is not provided .NET does the default initialization
        public Book(string name)
        {
            grades = new List<double>();
            // the this (keyword) refers to the object that is currently being operated on. 
            // Assign the parameter name (above) to the Books name variable within Class books.
            this.name = name;
        }
        // Field Definitition, looks very much like a variable declaration

        // Add grade is an INSTANCE MEMBER of the class book. 
        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }
        // ACCESS MODIFIERS
        // The keyword `public` is an accesss modifier, it controls where you can use that function it precedes.
        // public means code outside of this class can be used outside of the book class
        // The method GetGradeAverage is a MEMBER of the Class book
        public void GetGradeAverage()
        {
            // var (implicit typing) vs using explicity typing string, int, double, byte, etc.
            //Initialize a list
            double sum = 0.0;
            foreach (var n in grades)
            {
                sum += n;
            }
            double avg;
            double count = grades.Count;
            avg = sum / grades.Count;
            Console.WriteLine($"{name}'s average grade is {avg:N2}");
        }

        public void ShowStatistics()
        {
            this.GetGradeAverage();
            this.GetHighestGrade();
            this.GetLowestGrade();
        }

        public double GetHighestGrade()
        {
            // start highestGrade at the lowest possible value
            var highestGrade = double.MinValue;
            foreach (var grade in grades)
            {
                if (grade > highestGrade)
                {
                    highestGrade = grade;
                }
            }
            Console.WriteLine($"{name}'s highest grade is {highestGrade}");
            return highestGrade;
        }

        public double GetLowestGrade()
        {
            // start highestGrade at the lowest possible value
            var lowestGrade = double.MaxValue;
            foreach (var grade in grades)
            {
                lowestGrade = Math.Min(grade, lowestGrade);
            }
            Console.WriteLine($"{name}'s lowest grade is {lowestGrade}");
            return lowestGrade;
        }


        // The private keyword make it so the variable/method is only avaiable to other members of the class.
        // the variables below are called INSTANCE FIELDS
        private List<double> grades;
        private string name;

    }
}