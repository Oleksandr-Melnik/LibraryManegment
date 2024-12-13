using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManegmentTest
{
    public class Library
    {
        private List<Reader> readers = new List<Reader>(); // Список читачів

        public void AddReader(Reader reader)
        {
            if (readers.Any(r => r.ReaderId == reader.ReaderId))
                throw new InvalidOperationException("Reader with the same ID already exists.");
            readers.Add(reader);
        }

        public void RemoveReader(int readerId)
        {
            var reader = readers.FirstOrDefault(r => r.ReaderId == readerId);
            if (reader == null)
                throw new InvalidOperationException("Reader not found.");

            if (reader.BorrowedBooks.Any())
                throw new InvalidOperationException("Cannot remove reader with active loans.");


            readers.Remove(reader);
        }

        public List<Reader> GetAllReaders()
        {
            return readers;
        }
    }
}