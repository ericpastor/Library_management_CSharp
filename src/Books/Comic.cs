namespace BookManagement;

public class Comic : Book
{
    public string? Artist { get; set; }

    public Comic(string title, string artist, string author, string isbn, int publicationYear) : base(title, author, isbn, publicationYear, true, false)
    {
        this.Artist = artist;
    }

    public override string ToString()
    {
        var message = Messages(CanBorrow, CanPrint);
        return $"Title: {Title}\n Artist:{Artist}\n Author: {Author}\n ISBN: {Isbn}\n Publication year: {PublicationYear}\n Characteristics: {message[0]} / {message[1]}\n";
    }

    public override void Update(Book updatedBook)
    {
        var updatedComic = (Comic)updatedBook;
        Title = updatedComic.Title;
        Author = updatedComic.Author;
        Artist = updatedComic.Artist;
        Author = updatedComic.Author;
        Isbn = updatedComic.Isbn;
        PublicationYear = updatedComic.PublicationYear;
        CanBorrow = updatedComic.CanBorrow;
        CanPrint = updatedComic.CanPrint;
    }
}
