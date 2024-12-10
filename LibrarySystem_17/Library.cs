using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem
{
    public class Library
    {
        private readonly List<Book> books = new List<Book>();
        private readonly List<Reader> readers = new List<Reader>();
        private readonly List<Loan> activeLoans = new List<Loan>();

        // Додати книгу
        public void AddBook(Book book) => books.Add(book);

        // Додати читача
        public void AddReader(Reader reader) => readers.Add(reader);

        // Додати позику (тільки для тестів)
        public void AddLoan(Loan loan) => activeLoans.Add(loan);

        // Отримати книгу за ISBN
        public Book GetBookByISBN(string isbn) => books.FirstOrDefault(b => b.ISBN == isbn);

        // Отримати читача за ID
        public Reader GetReaderById(int readerId) => readers.FirstOrDefault(r => r.Id == readerId);


        // Отримати список активних позик
        public List<Loan> GetActiveLoans()
        {
            return activeLoans;
        }


        // Метод видачі книги 

        public bool BorrowBook(int readerId, string isbn)
        {
            var book = books.FirstOrDefault(b => b.ISBN == isbn);
            if (book == null || book.AvailableCopies <= 0) return false;

            var reader = readers.FirstOrDefault(r => r.Id == readerId);
            if (reader == null || reader.BorrowedBooks.Count >= 5) return false;

            if (activeLoans.Any(l => l.ReaderId == readerId && l.ISBN == isbn)) return false;

            book.AvailableCopies--;
            reader.BorrowedBooks.Add(isbn);
            activeLoans.Add(new Loan { ReaderId = readerId, ISBN = isbn, BorrowDate = DateTime.Now });

            return true;
        }



        // Метод повернення книги 
        public bool ReturnBook(int readerId, string isbn)
        {
            var loan = activeLoans.FirstOrDefault(l => l.ReaderId == readerId && l.ISBN == isbn);
            if (loan == null) return false;

            var book = books.FirstOrDefault(b => b.ISBN == isbn);
            var reader = readers.FirstOrDefault(r => r.Id == readerId);
            if (book == null || reader == null) return false;

            book.AvailableCopies++;
            reader.BorrowedBooks.Remove(isbn);
            activeLoans.Remove(loan);

            return true;
        }



    }
}
