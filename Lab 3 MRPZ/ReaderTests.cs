using Xunit;

namespace LibraryManegmentTest
{
    public class ReaderTests
    {
        [Fact]
        public void CreateReader_ShouldInitializeProperties()
        {
            // Arrange
            var reader = new Reader("John Doe", 1);

            // Act & Assert
            Assert.Equal("John Doe", reader.Name);
            Assert.Equal(1, reader.ReaderId);
            Assert.Empty(reader.BorrowedBooks);
        }
    }
}
