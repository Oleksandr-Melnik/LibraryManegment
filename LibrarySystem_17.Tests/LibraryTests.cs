using LibraryManagementSystem;
using LibraryManagementSystem.Models;
using Xunit;

public class LibraryTests
{
    [Fact]

    //Тест перевіряє, чи може читач взяти книгу,
    //якщо вона доступна, та чи змінюється кількість доступних копій
    public void BorrowBook_BookAvailable_UpdatesLoanAndCopies()
    {
        // Arrange
        var library = new Library();
        library.AddBook(new Book { ISBN = "123", Title = "Book A", TotalCopies = 5, AvailableCopies = 5 });
        library.AddReader(new Reader { Id = 1, Name = "John Doe" });

        // Act
        var result = library.BorrowBook(1, "123");

        // Assert
        Assert.Equal("Book borrowed successfully.", result);
        Assert.Equal(4, library.GetBookByISBN("123").AvailableCopies);
        Assert.Contains("123", library.GetReaderById(1).BorrowedBooks);
    }




    [Fact]
    public void ReturnBook_BookReturned_UpdatesCopiesAndLoans() //Тест для повернення книги
    {
        // Arrange
        var library = new Library();
        library.AddBook(new Book { ISBN = "123", Title = "Book A", TotalCopies = 5, AvailableCopies = 4 });
        library.AddReader(new Reader { Id = 1, Name = "John Doe", BorrowedBooks = new List<string> { "123" } });
        library.AddLoan(new Loan { ReaderId = 1, ISBN = "123", BorrowDate = DateTime.Now });

        // Act
        var result = library.ReturnBook(1, "123");

        // Assert
        Assert.Equal("Book returned successfully.", result);
        Assert.Equal(5, library.GetBookByISBN("123").AvailableCopies);
        Assert.DoesNotContain("123", library.GetReaderById(1).BorrowedBooks);
        Assert.Empty(library.GetActiveLoans());
    }




    [Fact]
    public void GetActiveLoans_ReturnsCorrectLoans() //Тест для перегляду активних позик
    {
        // Arrange
        var library = new Library();
        library.AddLoan(new Loan { ReaderId = 1, ISBN = "123", BorrowDate = DateTime.Now });
        library.AddLoan(new Loan { ReaderId = 2, ISBN = "456", BorrowDate = DateTime.Now });

        // Act
        var loans = library.GetActiveLoans();

        // Assert
        Assert.Equal(2, loans.Count);
        Assert.Contains(loans, l => l.ReaderId == 1 && l.ISBN == "123");
        Assert.Contains(loans, l => l.ReaderId == 2 && l.ISBN == "456");
    }

}
