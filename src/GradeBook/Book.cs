using System;
using System.Collections.Generic;


namespace GradeBook
{
    class Book
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
            Console.WriteLine($"The student's average grade is {avg:N2}");
        }
        public void GetHighestGrade() {
            var highestGrade = 0.0;
            foreach(var grade in grades) {
                if(grade > highestGrade) {
                    highestGrade = grade;
                }
            }
            Console.WriteLine(highestGrade);
        }
        // The private keyword make it so the variable/method is only avaiable to other members of the class.
        // the variables below are called INSTANCE FIELDS
        private List<double> grades;
        private string name;
    
    }
}