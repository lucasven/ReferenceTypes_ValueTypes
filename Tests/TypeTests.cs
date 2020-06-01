using ReferenceTypes_ValueTypes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests
{
    public class TypeTests
    {
        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = getInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        private int getInt()
        {
            return 3;
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Scott";
            var upper = MakeUpperCase(name);

            Assert.Equal("Scott", name);
            Assert.Equal("SCOTT", upper);
        }

        private string MakeUpperCase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void CSharpCanPassByReference()
        {
            //arrange
            var book1 = GetBook("Book 1");
            GetBookSetNameByReference(ref book1, "new name");

            //assert
            Assert.Equal("new name", book1.Name);
        }

        private void GetBookSetNameByReference(ref Book book, string name)
        {
            book = new Book(name);
            book.Name = name;
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            //arrange
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "new name");

            //assert
            Assert.NotEqual("new name", book1.Name);
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
            book.Name = name;
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            //arrange
            var book1 = GetBook("Book 1");
            SetName(book1, "new name");

            //assert
            Assert.Equal("new name", book1.Name);
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            //arrange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            //assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
        }
    }
}
