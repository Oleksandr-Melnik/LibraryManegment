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
    }

}
