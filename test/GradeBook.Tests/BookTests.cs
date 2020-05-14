using System;
//xunit is not a part of .NET core, it is a Nuget package available for .Net Core
using Xunit;

namespace GradeBook.Tests
{
    // GOAL: write unit tests that will verify the logic inside the Book class that lives inside the GradeBook project 
    // Name you test after the Class
    public class BookTests
    {
        // Fact is an ATTRIBUTE in C# 
        // an attribute is a little piece of data that is attached to the symbol that follow it.
        // In the example below, Fact is a little piece of data or ATTRIBUTE that is ATTACHED to Test1()
        // We decorate unit testing methods with the Fact method
        [Fact]
        public void ItReturnsHighestGrade()
        {
            // arrange
            var book = new Book("Test Book");
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
           public void ItReturnsLowestGrade()
        {
            // arrange
            var book = new Book("Test Book");
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
           public void ItReturnsAverageGrade()
        {
            // arrange
            var book = new Book("Test Book");
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
            var book = new Book("Test Book");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            
            // act
            var result = book.GetStatistics();
            
            // assert
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);

        }
        // unit tests are broken into 3 DISTINCT SECTIONS:
        // 1) The ARRANGE Section - where you put together all test data, organize for following sections
        // 2) The ACT Section - do something that produces a result
        // 3) The ASSERT Section - verify that the expected result matches(or doesn't match) the actual result
    }

}
