namespace BookManagement;

public class TextBook : Book
{
    public TextBook(string title, string author, string isbn, int publicationYear) : base(title, author, isbn, publicationYear, true, true) { }

    public override string ToString()
    {
        var message = Messages(CanBorrow, CanPrint);
        return $"Title: {Title}\n Author: {Author}\n ISBN: {Isbn}\n Publication year: {PublicationYear}\n Characteristics: {message[0]} / {message[1]}\n";
    }

    public override void Update(Book updatedBook)
    {
        var updatedTextBook = (TextBook)updatedBook;
        Title = updatedTextBook.Title;
        Author = updatedTextBook.Author;
        Author = updatedTextBook.Author;
        Isbn = updatedTextBook.Isbn;
        PublicationYear = updatedTextBook.PublicationYear;
        CanBorrow = updatedTextBook.CanBorrow;
        CanPrint = updatedTextBook.CanPrint;
    }
}
