using System;
using System.Collections.Generic;


namespace GradeBook
{
    class Book
    {
        //Write an explicit constructor if a constructor is not provided .NET does the default initialization
        public Book()
        {
            grades = new List<double>();
        }
        // Field Definitition, looks very much like a variable declaration
        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }
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
        
        List<double> grades;
    }
}