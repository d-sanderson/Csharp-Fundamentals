using System;
using System.Collections.Generic;
using System.IO;
// UNIT Testing 
// Write code that tests edge cases and common input to make sure your code is working working as intended.
// We use a testrunner to run unit tests. xUnit.net is a test runner we will be using in this course
namespace GradeBook
{
    //  ONE FILE PER TYPE WITH C# Programming(We aren't doing that here lol)
    //  Build a DELEGATE to define an EVENT
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }
    // INTERFACE DEFINITION - looks similar to a Class definition but it is "pure" - it contains no implementation details.
    // Interfaces only describe the Members that should be available on a specific type
    public interface IBook
    {
        // notice no ACCESS MODIFIER here
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }


    // Book is an abstract class that inherits the properties of NamedObject Class, and must have members describe in IBook Interface
    // Cant specify multiply Inheritance but you can specify 0 or more Interfaces!!
    public abstract class Book : NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {

        }

        public abstract event GradeAddedDelegate GradeAdded;

        //  ABSTRACT method - anything that is a Book Base should have an AddGrade Member, 
        //  but let the derived types figure out this implementations
        public abstract void AddGrade(double grade);

        // Heres a method thats in this class 
        public abstract Statistics GetStatistics();
    }



    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {

            // wrapping with USING statements allows you to create and dispose of object. 
            // Its implicitly running writer.Close(); writer.Dispose();
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }

            }
            //writer.Dispose();
        }

        public override Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }
    }


    // Book is a NamedObject (it is inheriting the Named object class)
    public class InMemoryBook : Book
    {
        // CLASS CONSTRUCTOR
        // Write an explicit constructor if a constructor is not provided .NET does the default initialization.
        // The base() method is accessing the CONSTRUCTOR of the the base class - NamedObject
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            // the this (keyword) refers to the object that is currently being operated on. 
            // Assign the parameter name (above) to the Books name variable within Class books.
            Name = name;
        }
        // Field Definitition, looks very much like a variable declaration

        // Add grade is an INSTANCE MEMBER of the class book. 
        // override overides the METHOD provided in the Base class.
        // In this case, it's overriding the AddGrade method of the BookBase class.
        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    // AddGrade is the sender (1st arg), event args (2nd arg) can be passed along to send information i.e passing the value of the entered grade.
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                // there is something wrong with one of the arguments in this method
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
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
        // An EVENT much like a FIELD, METHOD, or PROPERTY can be a MEMBER within a Class
        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            var avg = this.GetGradeAverage();
            var highest = this.GetHighestGrade();
            var lowest = this.GetLowestGrade();
            var avgLtrGrade = this.GetGradeLetterAverage();
            result.High = highest;
            result.Low = lowest;
            result.Average = avg;
            result.Letter = avgLtrGrade;
            return result;
        }

        private char GetGradeLetterAverage()
        {
            var avg = this.GetGradeAverage();
            switch (avg)
            {
                case var d when d >= 90.0:
                    return 'A';
                case var d when d >= 80.0:
                    return 'B';

                case var d when d >= 70.0:
                    return 'C';

                case var d when d >= 60.0:
                    return 'D';
                default:
                    return 'F';
            }
        }

        public string ShowStatistics()
        {
            var result = this.GetStatistics();
            return $"{Name}'s average grade is {result.Average:N2}, Their average letter Grade is {result.Letter}. {Name}'s highest grade is {result.High}. {Name}'s lowest grade is {result.Low}";
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

            return lowestGrade;
        }
        // Method Overloading AddGrade above takes a double here it takes a char. 
        // This changes the method signature and allows you to have two methods that have the same name.
        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                case 'F':
                    AddGrade(50);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        public List<double> GetGrades()
        {
            return grades;
        }
        // The private keyword make it so the variable/method is only avaiable to other members of the class.
        // the variables below are called INSTANCE FIELDS
        private List<double> grades;
        // a public member always has an Uppercase name
        // public string Name;

        // PROPERTIES

        // Access modifier (public)
        // public string Name
        // {
        // Auto Property - shorthand version 
        // get;
        // With the private access modifier, if an operation wants to write to name outside of the Book class, it cannot.
        // set;
        // get
        // {
        //     return name.ToUpper();
        // }
        // set
        // {
        //     // Implicit variable named value is accessible with your set method
        //     if (value == null)
        //     {
        //     }
        //     else if (!String.IsNullOrEmpty(value))
        //     {
        //         name = value;
        //     }
        // }
    }
}
// Property VS Field they are very similar but there are differences some come up during Serialization and Reflection. You can apply different access modifiers to get and set.
// private string name;

// With the READONLY keyword, this field can only INITIALIZE or CHANGE in the constructor
// readonly string category;

// const fields are treated like they are static members in the Class.
// public const string CATEGORY = "PSYOPS";

