using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LibraryManegmentTest
{
    public class LibraryTests
    {
        [Fact]
        public void AddReader_ShouldAddReaderToLibrary()
        {
            // Arrange
            var library = new Library();
            var reader = new Reader("John Doe", 1);

            // Act
            library.AddReader(reader);

            // Assert
            Assert.Contains(reader, library.GetAllReaders());
        }

        [Fact]
        public void AddReader_ShouldThrowException_IfReaderIdNotUnique()
        {
            // Arrange
            var library = new Library();
            var reader1 = new Reader("John Doe", 1);
            var reader2 = new Reader("Jane Doe", 1);
            library.AddReader(reader1);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => library.AddReader(reader2));
        }

        [Fact]
        public void RemoveReader_ShouldRemoveReaderFromLibrary()
        {
            // Arrange
            var library = new Library();
            var reader = new Reader("John Doe", 1);
            library.AddReader(reader);

            // Act
            library.RemoveReader(1);

            // Assert
            Assert.DoesNotContain(reader, library.GetAllReaders());
        }

        [Fact]
        public void RemoveReader_ShouldThrowException_IfReaderHasActiveLoans()
        {
            // Arrange
            var library = new Library();
            var reader = new Reader("John Doe", 1);
            reader.BorrowedBooks.Add("123456789");
            library.AddReader(reader);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => library.RemoveReader(1));
        }

        [Fact]
        public void GetAllReaders_ShouldReturnAllRegisteredReaders()
        {
            // Arrange
            var library = new Library();
            var reader1 = new Reader("John Doe", 1);
            var reader2 = new Reader("Jane Doe", 2);

            library.AddReader(reader1);
            library.AddReader(reader2);

            // Act
            var allReaders = library.GetAllReaders();

            // Assert
            Assert.Equal(2, allReaders.Count);
            Assert.Contains(reader1, allReaders);
            Assert.Contains(reader2, allReaders);
        }
    }
}
