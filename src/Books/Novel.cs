namespace BookManagement;

public class Novel : Book
{
    public string? Genre { get; set; }
    public Novel(string title, string genre, string author, string isbn, int publicationYear) : base(title, author, isbn, publicationYear, true, false)
    {
        this.Genre = genre;
    }

    public override string ToString()
    {
        var message = Messages(CanBorrow, CanPrint);
        return $"Title: {Title}\n Genre:{Genre}\n Author: {Author}\n ISBN: {Isbn}\n Publication year: {PublicationYear}\n Characteristics: {message[0]} / {message[1]}\n";
    }

    public override void Update(Book updatedBook)
    {
        var updatedNovel = (Novel)updatedBook;
        Title = updatedNovel.Title;
        Author = updatedNovel.Author;
        Genre = updatedNovel.Genre;
        Author = updatedNovel.Author;
        Isbn = updatedNovel.Isbn;
        PublicationYear = updatedNovel.PublicationYear;
        CanBorrow = updatedNovel.CanBorrow;
        CanPrint = updatedNovel.CanPrint;
    }
}
