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
   
        public string BorrowBook(int readerId, string isbn)
        {
            // 1. Перевірка наявності книги
            var book = books.FirstOrDefault(b => b.ISBN == isbn);
            if (book == null)
                return "Book not found.";

            // 2. Перевірка доступності книги
            if (book.AvailableCopies <= 0)
                return "Book is not available.";

            // 3. Перевірка існування читача
            var reader = readers.FirstOrDefault(r => r.Id == readerId);
            if (reader == null)
                return "Reader not found.";

            // 4. Обмеження на кількість позик
            if (reader.BorrowedBooks.Count >= 5)
                return "Reader has reached the borrowing limit.";

            // 5. Перевірка на унікальність позики
            if (activeLoans.Any(l => l.ReaderId == readerId && l.ISBN == isbn))
                return "Book is already borrowed by this reader.";

            // Якщо всі перевірки пройдені, видаємо книгу
            book.AvailableCopies--;
            reader.BorrowedBooks.Add(isbn);
            activeLoans.Add(new Loan { ReaderId = readerId, ISBN = isbn, BorrowDate = DateTime.Now });

            return "Book borrowed successfully.";
        }



        // Метод повернення книги 
        public string ReturnBook(int readerId, string isbn)
        {
            // 1. Перевірка наявності активної позики
            var loan = activeLoans.FirstOrDefault(l => l.ReaderId == readerId && l.ISBN == isbn);
            if (loan == null)
                return "No active loan found for this book and reader.";

            // 2. Перевірка існування книги
            var book = books.FirstOrDefault(b => b.ISBN == isbn);
            if (book == null)
                return "Book not found.";

            // 3. Перевірка існування читача
            var reader = readers.FirstOrDefault(r => r.Id == readerId);
            if (reader == null)
                return "Reader not found.";

            // Якщо всі перевірки пройдені, повертаємо книгу
            book.AvailableCopies++;
            reader.BorrowedBooks.Remove(isbn);
            activeLoans.Remove(loan);

            return "Book returned successfully.";
        }


    }
}
