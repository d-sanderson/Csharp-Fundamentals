using System;
using System.Collections.Generic;


namespace GradeBook
{
    class Book
    {

        public void AddGrade(double grade)
        {
        var grades = new List<double>() { 43.5, 2.5, 31.5 };
        grades.Add(grade);
        System.Console.WriteLine(grades.Count);
        }
    }
}