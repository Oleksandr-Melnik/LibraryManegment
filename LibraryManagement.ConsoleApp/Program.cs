using LibraryManagement;
using LibraryManegmentTest;
using System;

namespace LibraryManagement.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Library Management System Demo");

            // Створення об'єкта бібліотеки
            Library library = new Library();

            // Додавання читачів
            try
            {
                library.AddReader(new Reader("John Doe", 1));
                library.AddReader(new Reader("Jane Smith", 2));
                Console.WriteLine("Readers added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while adding readers: {ex.Message}");
            }

            // Перегляд усіх читачів
            Console.WriteLine("\nCurrent list of readers:");
            foreach (var reader in library.GetAllReaders())
            {
                Console.WriteLine($"Reader ID: {reader.ReaderId}, Name: {reader.Name}");
            }

            // Видалення читача
            try
            {
                library.RemoveReader(1); // Видаляємо читача з ID 1
                Console.WriteLine("\nReader with ID 1 removed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while removing reader: {ex.Message}");
            }

            // Перегляд читачів після видалення
            Console.WriteLine("\nList of readers after removal:");
            foreach (var reader in library.GetAllReaders())
            {
                Console.WriteLine($"Reader ID: {reader.ReaderId}, Name: {reader.Name}");
            }

            Console.WriteLine("\nDemo completed. Press any key to exit...");
        }
    }
}
