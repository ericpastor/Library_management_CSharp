using BookManagement;
using LibraryManagement;
using UsersManagement;

internal class Program
{
    private static void Main()
    {
        var lib = new Library();

        Console.WriteLine($"PrintInfo method:");
        lib.PrintInfo("Mortadelo");
        lib.PrintInfo("Shantaram");
        lib.PrintInfo("(IMDG) Code");
        lib.PrintInfo("Matemáticas avanzadas");

        Console.WriteLine($"");

        Console.WriteLine($"Loan and collect methods");
        lib.Loan("Mortadelo", 1);
        lib.Loan("Mortadelo", 4);
        lib.Collect("Mortadelo", 1);

        Console.WriteLine($"");

        Console.WriteLine($"PintPages method:");
        lib.PrintPages("Mortadelo", 43, 76, 4);
        lib.PrintPages("(IMDG) Code", 43, 200, 1);
        lib.PrintPages("Matemáticas avanzadas", 43, 76, 4);

        Console.WriteLine($"");

        Console.WriteLine($"AddBook method:");
        var b1 = new Novel("La Conquista para escépticos", "History", "Galan", "HJDHS542542356", 2019);
        lib.AddBook(b1, 4);
        lib.AddBook(b1, 1);

        Console.WriteLine($"");

        Console.WriteLine($"Removing a book:");
        lib.RemoveBook("M12736DSG", 4);
        lib.RemoveBook("Matemáticas avanzs", 3);

        Console.WriteLine($"");

        Console.WriteLine($"Updating a book:");
        lib.EditBook("Imo5357w", new ResearchPaper("", "Jan Smith", "IMO6654R778", 0), 4);
        Console.WriteLine($"Book iformation:");
        lib.PrintInfo("(IMDG) Code");

        Console.WriteLine($"");

        Console.WriteLine($"All Books:");
        lib.PrintBooks();

        Console.WriteLine($"");

        Console.WriteLine($"Find user by Name:");
        lib.UserInfo("Rafael Cantero", 4);

        Console.WriteLine($"");

        Console.WriteLine($"Adding a user:");
        var u1 = new Librarian("Jos Bayer");
        lib.AddUser(u1, 4);

        Console.WriteLine($"");

        Console.WriteLine($"Removing a user:");
        lib.RemoveUser("Amadó Garcia", 4);

        Console.WriteLine($"");

        Console.WriteLine($"Updating a user:");
        lib.EditUser(5, new Librarian("Jos Red"), 4);
        Console.WriteLine($"User iformation:");
        lib.UserInfo("Jos Red", 4);

        Console.WriteLine($"All Users:");
        lib.PrintUsers();
    }
}