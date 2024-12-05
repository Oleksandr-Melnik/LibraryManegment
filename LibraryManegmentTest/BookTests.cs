namespace LibraryManegmentTest
{
    public class BookTests
    {
        [Fact]
        public void CreateBook_ShouldInitializeProperties()
        {
            // Arrange
            var book = new Book("1984", "George Orwell", "123456789", 5);

            // Act & Assert
            Assert.Equal("1984", book.Title); // �������, �� ����� ���� ����������
            Assert.Equal("George Orwell", book.Author); // ����� �� ���� ����������
            Assert.Equal("123456789", book.ISBN); // ISBN �� ���� ���������
            Assert.Equal(5, book.CopiesAvailable); // ʳ������ ���� �� ���������
        }
    }
}