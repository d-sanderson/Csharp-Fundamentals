using System;
//xunit is not a part of .NET core, it is a Nuget package available for .Net Core
using Xunit;


namespace GradeBook.Tests
{
    // GOAL: write unit tests that will verify the logic inside the Book class that lives inside the GradeBook project 
    // Name tests Class after the Class they test I.E BookTests include tests for the Book Class.

    // unit tests are broken into 3 DISTINCT SECTIONS:
    // 1) The ARRANGE Section - where you put together all test data, organize for following sections
    // 2) The ACT Section - do something that produces a result
    // 3) The ASSERT Section - verify that the expected result matches(or doesn't match) the actual result
    public class BookTests
    {
        // Fact is an ATTRIBUTE in C# 
        // an attribute is a little piece of data that is attached to the symbol that follow it.
        // In the example below, Fact is a little piece of data or ATTRIBUTE that is ATTACHED to Test1()
        // We decorate unit testing methods with the Fact method
        [Fact]
        public void BookReturnsHighestGrade()
        {
            // arrange
            var book = new InMemoryBook("Test Book");
            book.AddGrade(99.9);
            book.AddGrade(49.3);
            book.AddGrade(39.3);
            book.AddGrade(29.3);
            book.AddGrade(19.3);
            var expected = 99.9;

            // act
            var actual = book.GetHighestGrade();

            // assert
            Assert.Equal(actual, expected);

        }
        [Fact]
        public void BookReturnsLowestGrade()
        {
            // arrange
            var book = new InMemoryBook("Test Book");
            book.AddGrade(99.9);
            book.AddGrade(49.3);
            book.AddGrade(39.3);
            book.AddGrade(29.3);
            book.AddGrade(19.3);
            var expected = 19.3;

            // act
            var actual = book.GetLowestGrade();

            // assert
            Assert.Equal(actual, expected);

        }
        [Fact]
        public void BookReturnsAverageGrade()
        {
            // arrange
            var book = new InMemoryBook("Test Book");
            book.AddGrade(99.9);
            book.AddGrade(49.3);
            book.AddGrade(39.3);
            book.AddGrade(29.3);
            book.AddGrade(19.3);
            var expected = 47.42;

            // act
            var actual = book.GetGradeAverage();

            // assert
            Assert.Equal(actual, expected);

        }
        [Fact]
        public void TestGetStats()
        {
            // arrange
            var book = new InMemoryBook("Test Book");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);


            // act
            var result = book.GetStatistics();

            // assert
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('B', result.Letter);
        }
        [Fact]
        public void BookWontAcceptInvalidGrade()
        {
            // arrange
            var book = new InMemoryBook("Test Book");
            book.AddGrade(-5.0);
            book.AddGrade(344);
            var grades = book.GetGrades();
            // assert
            Assert.Equal(0, grades.Count);

        }
    }

}

// Difference between VALUE types and REFERENCE types
// var b = new Book("grades");
// b is a REFERENCE TYPE
// when code is executed, a space is created in memory for the value b;
// Somewhere in the gbs of your system memory, there are memory cells where the .NET runtime allocates space and stores the value.
// The variable doesn't "contain" the Book it stores a reference to it.

// var x = 3;
// int x is a VALUE type
// runtime stores number directly in the variable

