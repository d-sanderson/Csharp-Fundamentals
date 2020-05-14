using System;
//xunit is not a part of .NET core, it is a Nuget package available for .Net Core
using Xunit;


namespace GradeBook.Tests
{
    // unit tests are broken into 3 DISTINCT SECTIONS:
    // 1) The ARRANGE Section - where you put together all test data, organize for following sections
    // 2) The ACT Section - do something that produces a result
    // 3) The ASSERT Section - verify that the expected result matches(or doesn't match) the actual result
    public class TypeTests
    {

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            // arrange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            // act
            // assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
        }
        // object is the lowest base type in the .NET framework
        Book GetBook(string name)
        {
            return new Book(name);
        }


    }

}
