using System;
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
            books.Add(book); // Виправлено: книга додається до списку
        }


        public List<Book> GetAllBooks()
        {
            return books;
        }
    }

}
