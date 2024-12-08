using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManegmentTest
{
    public class LibraryTests
    {
        [Fact]
        public void AddBook_ShouldAddBookToLibrary()
        {
            // Arrange
            var library = new Library();
            var book = new Book("1984", "George Orwell", "123456789", 5);

            // Act
            library.AddBook(book);

            // Assert
            Assert.Contains(book, library.GetAllBooks());
        }

        [Fact]
        public void AddBook_ShouldThrowException_IfISBNNotUnique()
        {
            // Arrange
            var library = new Library();
            var book1 = new Book("1984", "George Orwell", "123456789", 5);
            var book2 = new Book("Animal Farm", "George Orwell", "123456789", 3);
            library.AddBook(book1);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => library.AddBook(book2));
        }

        [Fact]
        public void RemoveBook_ShouldRemoveBookFromLibrary()
        {
            // Arrange
            var library = new Library();
            var book = new Book("1984", "George Orwell", "123456789", 5);
            library.AddBook(book);

            // Act
            library.RemoveBook("123456789");

            // Assert
            Assert.DoesNotContain(book, library.GetAllBooks());
        }
    }

}
