using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManegmentTest
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int CopiesAvailable { get; set; }

        public Book(string title, string author, string isbn, int copiesAvailable)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            CopiesAvailable = 0; // ПОМИЛКА: завжди 0 копій
        }
    }

}
