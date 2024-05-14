using interfaces;
using Interfaces;

namespace BookManagement;

public abstract class Book : IBorrowable, IPrintPages
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Isbn { get; set; }
    public int PublicationYear { get; set; }
    public bool CanBorrow { get; set; }
    public bool CanPrint { get; set; }


    public Book(string title, string author, string isbn, int publicationYear, bool canBorrow, bool canPrint)
    {
        this.Title = title;
        this.Author = author;
        this.Isbn = isbn;
        this.PublicationYear = publicationYear;
        this.CanBorrow = canBorrow;
        this.CanPrint = canPrint;
    }

    public void Borrow(string title)
    {
        if (CanBorrow)
        {
            var now = DateTime.Now.ToLongDateString();
            Console.WriteLine($"Book: {title} borrowed on {now}");
        }
        else
        {
            Console.WriteLine($"Not allowed to borrow");
        }
    }

    public void Return(string title)
    {
        var now = DateTime.Now.ToLongDateString();
        Console.WriteLine($"Book: {title} returned on {now}");

    }

    public abstract void Update(Book udatedBook);

    public void Print(string title, int startPage, int endPage)
    {
        if (CanPrint)
        {
            var numOfPages = endPage - startPage;
            if (numOfPages > 50)
            {
                Console.WriteLine($"Not allowed to print more than 50 pages");
            }
            if (numOfPages <= 0)
            {
                Console.WriteLine($"At least we need 1 page to print");
            }
            if (numOfPages > 0 && numOfPages <= 50)
            {

                Console.WriteLine($"Printing {numOfPages} pages from {title}");
            }
        }
        else
        {
            Console.WriteLine($"'{Title}' is not allowed to print any pages");

        }

    }

    public static string[] Messages(bool canBorrow, bool canPrint)
    {
        var messages = new string[2]
        {
            canBorrow ? "Borrowable" : "Not allowed to borrow",
            canPrint ? "Allowed to print 50 pages max." : "Not allowed to print"
        };

        return messages;
    }
}
