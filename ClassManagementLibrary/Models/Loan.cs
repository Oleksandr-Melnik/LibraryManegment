using System;

namespace LibraryManagementSystem.Models
{
    public class Loan
    {
        public int ReaderId { get; set; }
        public string ISBN { get; set; }
        public DateTime BorrowDate { get; set; }
    }
}
