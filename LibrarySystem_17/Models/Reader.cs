using System.Collections.Generic;

namespace LibraryManagementSystem.Models
{
    public class Reader
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> BorrowedBooks { get; set; } = new List<string>();
    }
}
