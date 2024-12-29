using LibraryManagementSystem;
using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;



//Console.WriteLine("Бiблiотечна система. Виберiть дiю:");
//while (true)
//{
//    Console.WriteLine("\n1. Взяти книгу у позику");
//    Console.WriteLine("2. Повернути книгу");
//    Console.WriteLine("3. Показати активнi позики");
//    Console.WriteLine("4. Вийти");
//    Console.Write("Ваш вибiр: ");
//    var choice = Console.ReadLine();

//    switch (choice)
//    {
//        case "1":
//            BorrowBook(library);
//            break;
//        case "2":
//            ReturnBook(library);
//            break;
//        case "3":
//            ShowActiveLoans(library);
//            break;
//        case "4":
//            Console.WriteLine("До побачення!");
//            return;
//        default:
//            Console.WriteLine("Невiрний вибiр, спробуйте ще раз.");
//            break;
//    }
//}
//static void InitializeLibrary(Library library)
//{
//    // Додаємо кілька тестових книг і читачів
//    library.AddBook(new Book { ISBN = "123", Title = "C# Basics", TotalCopies = 3, AvailableCopies = 3 });
//    library.AddBook(new Book { ISBN = "456", Title = "Advanced C#", TotalCopies = 2, AvailableCopies = 2 });
//    library.AddReader(new Reader { Id = 1, Name = "John Doe" });
//    library.AddReader(new Reader { Id = 2, Name = "Jane Smith" });
//}
//static void BorrowBook(Library library)
//{
//    try
//    {
//        Console.Write("ID читача: ");
//        int readerId = int.Parse(Console.ReadLine()); // Можливий FormatException
//        Console.Write("ISBN книги: ");
//        string isbn = Console.ReadLine();

//        if (library.BorrowBook(readerId, isbn))
//            Console.WriteLine("Книгу успiшно взято у позику.");
//        else
//            Console.WriteLine("Не вдалося взяти книгу. Перевiрте данi.");
//    }
//    catch (FormatException)
//    {
//        Console.WriteLine("Помилка: ID читача має бути числом. Спробуйте ще раз.");
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine($"Сталася неочiкувана помилка: {ex.Message}");
//    }
//}

//static void ReturnBook(Library library)
//{
//    try
//    {
//        Console.Write("ID читача: ");
//        int readerId = int.Parse(Console.ReadLine()); // Можливий FormatException
//        Console.Write("ISBN книги: ");
//        string isbn = Console.ReadLine();

//        if (library.ReturnBook(readerId, isbn))
//            Console.WriteLine("Книгу успiшно повернено.");
//        else
//            Console.WriteLine("Не вдалося повернути книгу. Перевiрте данi.");
//    }
//    catch (FormatException)
//    {
//        Console.WriteLine("Помилка: ID читача має бути числом. Спробуйте ще раз.");
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine($"Сталася неочiкувана помилка: {ex.Message}");
//    }
//}




//static void ShowActiveLoans(Library library)
//{
//    var loans = library.GetActiveLoans();
//    if (loans.Count == 0)
//    {
//        Console.WriteLine("Немає активних позик.");
//    }
//    else
//    {
//        Console.WriteLine("Активнi позики:");
//        foreach (var loan in loans)
//        {
//            Console.WriteLine($"Читач ID: {loan.ReaderId}, Книга ISBN: {loan.ISBN}, Дата: {loan.BorrowDate}");
//        }
//    }
//}







var library = new Library();
InitializeLibrary(library);


Console.WriteLine("==== Демонстрація роботи бібліотеки ====");

 // Наталія бере книгу "123"
Console.WriteLine("\n1. Наталія бере книгу 'C# Basics':");
try
{
    bool borrowResult = library.BorrowBook(1, "123");
    if (borrowResult)
    {
        Console.WriteLine("Книгу успішно видано.");
      
        ShowActiveLoans(library);
    }
    else
    {
        Console.WriteLine("Не вдалося видати книгу. Перевірте дані або наявність книги.");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Помилка при взятті книги: {ex.Message}");
}

// Спроба взяти ту ж книгу ще раз
Console.WriteLine("\n2. Наталія намагається взяти ту ж книгу ще раз:");
try
{
    bool borrowResult = library.BorrowBook(1, "123");
    if (borrowResult)
    {
        Console.WriteLine("Книгу успішно видано.");
        
        ShowActiveLoans(library);
    }
    else
    {
        Console.WriteLine("Не вдалося видати книгу. Перевірте дані або наявність книги.");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Помилка при взятті книги: {ex.Message}");
}



// Жасмін намагається взяти неіснуючу книгу
Console.WriteLine("\n3. Жасмін намагається взяти неіснуючу книгу:");
try
{
    bool borrowResult = library.BorrowBook(2, "999"); // Неіснуючий ISBN
    if (borrowResult)
    {
        Console.WriteLine("Книгу успішно видано.");
       
        ShowActiveLoans(library);
    }
    else
    {
        Console.WriteLine("Не вдалося видати книгу. Перевірте дані або наявність книги.");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Помилка при взятті книги: {ex.Message}");
}


// Наталія повертає книгу
Console.WriteLine("\n4. Наталія повертає книгу 'C# Basics':");
try
{
    bool returnResult = library.ReturnBook(1, "123");
    if (returnResult)
    {
        Console.WriteLine("Книгу успішно повернуто.");
       
        ShowActiveLoans(library);
    }
    else
    {
        Console.WriteLine("Не вдалося повернути книгу.");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Помилка при поверненні книги: {ex.Message}");
}

Console.WriteLine("\n=== Демонстрація завершена ===");
        

        
   
static void ShowActiveLoans(Library library)
{
    var loans = library.GetActiveLoans();
    if (loans.Count == 0)
    {
        Console.WriteLine("Активних позик немає.");
    }
    else
    {
        Console.WriteLine("Активні позики:");
        foreach (var loan in loans)
        {
            Console.WriteLine($"ID читача: {loan.ReaderId}, ISBN: {loan.ISBN}, Дата видачі: {loan.BorrowDate}");
        }
    }
}

static void InitializeLibrary(Library library)
{
    library.AddBook(new Book { ISBN = "123", Title = "C# Basics", TotalCopies = 3, AvailableCopies = 3 });
    library.AddBook(new Book { ISBN = "456", Title = "Advanced C#", TotalCopies = 2, AvailableCopies = 2 });
    library.AddReader(new Reader { Id = 1, Name = "Наталія" });
    library.AddReader(new Reader { Id = 2, Name = "Жасмін" });
}