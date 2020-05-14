using System;
//xunit is not a part of .NET core, it is a Nuget package available for .Net Core
using Xunit;

namespace GradeBook.Tests
{
    public class UnitTest1
    {
        // Fact is an ATTRIBUTE in C# 
        // an attribute is a little piece of data that is attached to the symbol that follow it.
        // In the example below, Fact is a little piece of data or ATTRIBUTE that is ATTACHED to Test1()
        [Fact]
        public void Test1()
        {
            var x = 5;
            var y = 7;
            var actual = 12;
            var expected = 10;

            Assert.Equal(expected, actual);
        }
        // We decorate unit testing methods with the Fact method
       
    }
}
