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
        // We decorate unit testing methods with the Fact method
        [Fact]
        public void Test1()
        {

        }
       
    }
}
