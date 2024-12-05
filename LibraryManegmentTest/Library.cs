﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManegmentTest
{
    public class Library
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            if (books.Any(b => b.ISBN == book.ISBN))
                throw new InvalidOperationException("Book with the same ISBN already exists.");
            books.Add(book);
        }


        public List<Book> GetAllBooks()
        {
            return books;
        }
    }

}
