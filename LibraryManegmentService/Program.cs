// Program.cs in LibraryManegmentService
using LibraryManegmentTest;

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();

        Console.WriteLine("\nLibrary Management System");
        Console.WriteLine("1. Add a Book");
        Console.WriteLine("2. Remove a Book");
        Console.WriteLine("3. View All Books");
        Console.WriteLine("4. Exit");

        // Simulating user input for automated execution
        string choice = "1"; // Example: Automatically choose to add a book
        Console.WriteLine($"Selected option: {choice}");

        switch (choice)
        {
            case "1":
                string title = "Automated Book Title";
                string author = "Automated Author";
                string isbn = "1234567890";
                int copies = 5;

                Console.WriteLine($"Adding Book: Title={title}, Author={author}, ISBN={isbn}, Copies={copies}");

                try
                {
                    library.AddBook(new Book(title, author, isbn, copies));
                    Console.WriteLine("Book added successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                break;

            case "2":
                isbn = "1234567890"; // Example: Automatically remove a book with this ISBN
                Console.WriteLine($"Removing Book with ISBN={isbn}");

                try
                {
                    library.RemoveBook(isbn);
                    Console.WriteLine("Book removed successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                break;

            case "3":
                Console.WriteLine("Listing all books:");
                var books = library.GetAllBooks();

                if (books.Count == 0)
                {
                    Console.WriteLine("No books available.");
                }
                else
                {
                    foreach (var book in books)
                    {
                        Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}, Copies: {book.CopiesAvailable}");
                    }
                }
                break;

            case "4":
                Console.WriteLine("Exiting the program. Goodbye!");
                break;

            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }

        Console.WriteLine("Program execution completed.");
    }
}
