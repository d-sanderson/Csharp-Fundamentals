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
            // arrange / act
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");
            // assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
        }

        [Fact]
        public void TwoVariablesCanReferenceSameObject()
        {
            // arrange / act
            var book1 = GetBook("Book 1");
            // obj stores a point to some memory point in the computer
            var book2 = book1;
            // assert
            // Both of these REFERENCES are pointing to the same object in memory.
            Assert.Same(book2, book1);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book 1");
            // changes the name of an existing book object
            // below we pass a variable by REFERENCE, this allows us to modify the obj.
            // you can also use out, ref vs out out param c# assumes initial value won't be initialized. Output param must be initialized

            GetBookSetName(ref book1, "New Name");
            Assert.Equal("New Name", book1.Name);

        }
        // taking the reference to book and placing the reference(point) into the parameter
        private void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
            book.Name = name;
        }
        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            // changes the name of an existing book object
            // when you pass a parameter to a method by default you are passing the parameter by VALUE

            GetBookSetName(book1, "New Name");
            Assert.Equal("Book 1", book1.Name);

        }
        // taking value inside book1 and copying its value and placing it into the parameter
        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
            book.Name = name;
        }
        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");

            SetName(book1, "New Name");
            Assert.Equal("New Name", book1.Name);

        }
        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        // object is the lowest base type in the .NET framework
        // everything derives from the object base class
        Book GetBook(string name)
        {
            return new Book(name);
        }
        [Fact]
        public void Test2()
        {
            //  VALUE types are easier to test than REFERENCE types
            var x = GetInt();
            // If passed by Value 3 copied from x variable into SetInt param, copys new value into parameter location and doesnt change x
            // If passed by Reference you can update the value set in the SetInt method.
            SetInt(ref x);
            Assert.Equal(42, x);
        }

        private int SetInt(ref int x)
        {
            x = 42;
            return x;
        }

        private int GetInt()
        {
            return 3;
        }

        // How to differentiate a VALUE type from a REFERENCE type
        // defined by a Class? That's a reference type.
        // Struct a special value type that behaves like a value type, typically very small
        [Fact]
        public void StringBehaveLikeValueTypes()
        {
            // Type string is a REFERENCE type, but it often behaves like a VALUE type
            // strings are immutable, you cannot change a value after its declared
            string word = "david";
            var upper = MakeUpperCase(word);
            Assert.Equal(upper, "DAVID");
        }

        private string MakeUpperCase(string word)
        {
            return word.ToUpper();
        }
    }

}
