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
            
            readers.Add(reader);
        }

        public void RemoveReader(int readerId)
        {
            var reader = readers.FindAll(r => r.ReaderId == readerId).FirstOrDefault();
            if (reader == null)
                throw new InvalidOperationException("Reader not found.");

            

            readers.Remove(reader);
        }

        public List<Reader> GetAllReaders()
        {
            return readers;
        }
    }
}