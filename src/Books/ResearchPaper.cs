namespace BookManagement;

public class ResearchPaper : Book
{
    public ResearchPaper(string title, string author, string isbn, int publicationYear) : base(title, author, isbn, publicationYear, false, true) { }

    public override string ToString()
    {
        var message = Messages(CanBorrow, CanPrint);
        return $"Title: {Title}\n Author: {Author}\n ISBN: {Isbn}\n Publication year: {PublicationYear}\n Characteristics: {message[0]} / {message[1]}\n";
    }

    public override void Update(Book updatedBook)
    {
        var updatedResearchPaper = (ResearchPaper)updatedBook;
        Title = updatedResearchPaper.Title;
        Author = updatedResearchPaper.Author;
        Author = updatedResearchPaper.Author;
        Isbn = updatedResearchPaper.Isbn;
        PublicationYear = updatedResearchPaper.PublicationYear;
        CanBorrow = updatedResearchPaper.CanBorrow;
        CanPrint = updatedResearchPaper.CanPrint;
    }
}