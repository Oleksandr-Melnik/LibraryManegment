namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }
    }
}
