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
            Assert.Equal("1984", book.Title); // Очікуємо, що назва буде правильною
            Assert.Equal("George Orwell", book.Author); // Автор має бути правильним
            Assert.Equal("123456789", book.ISBN); // ISBN має бути унікальним
            Assert.Equal(5, book.CopiesAvailable); // Кількість копій має відповідати
        }
    }
}