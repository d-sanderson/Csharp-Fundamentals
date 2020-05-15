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
            Name = name;
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
        public double GetGradeAverage()
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
            return avg;
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            var avg = this.GetGradeAverage();
            var highest = this.GetHighestGrade();
            var lowest = this.GetLowestGrade();
            result.High = highest;
            result.Low = lowest;
            result.Average = avg;
            return result;
        }
        public void ShowStatistics()
        {
            var result = this.GetStatistics();
            Console.WriteLine($"{Name}'s average grade is {result.Average:N2}. {Name}'s highest grade is {result.High}. {Name}'s lowest grade is {result.Low}");
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
            Console.WriteLine($"");
            return lowestGrade;
        }

        // The private keyword make it so the variable/method is only avaiable to other members of the class.
        // the variables below are called INSTANCE FIELDS
        private List<double> grades;
        // a public member always has an Uppercase name
        public string Name;
    
    }
}