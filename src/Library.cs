using System.Reflection;
using BookManagement;
using UsersManagement;

namespace LibraryManagement;
public class Library
{
    public readonly Dictionary<string, Book> Books = new Dictionary<string, Book>();
    public readonly List<User> Users = new List<User>();

    public Library()
    {
        Books = new Dictionary<string, Book>
        {
          { "JSHDH42463", new Comic("Mortadelo", "Ibañez", "Ibanez", "JSHDH42463", 1978)},
           {"JSHD999463", new Novel("Shantaram", "Bibliography", "David", "JSHD999463", 2004)},
           {"Imo5357w", new ResearchPaper("(IMDG) Code", "IMO members", "Imo5357w", 1972)},
           {"M12736DSG", new TextBook("Matemáticas avanzadas", "Rachid M.", "M12736DSG", 1990)}
        };

        Users = new List<User>
        {
            new Customer("Rafael Cantero"),
            new Customer("Amadó Garcia"),
            new Customer("Pekka Karhu"),
            new Librarian("John Smith")
        };
    }

    // Methods directly related to Books
    public Book? GetBookByTitle(string title)
    {
        foreach (var bookEntry in Books)
        {
            if (bookEntry.Value.Title == title)
            {
                return bookEntry.Value;
            }
        }
        Console.WriteLine($"We don't have this Title: '{title}' in our system");
        return null;
    }

    public void PrintInfo(string title)
    {
        var bookToPrintInfo = GetBookByTitle(title);
        Console.WriteLine($"{bookToPrintInfo}");
    }

    public void Loan(string title, int id)
    {
        var user = GetUserById(id);
        var role = user?.Role;
        if (role == Role.Customer)
        {
            var bookToLoan = GetBookByTitle(title);
            bookToLoan?.Borrow(bookToLoan.Title);
        }
        else
        {
            Console.WriteLine($"You need to be a customer to borrow a book");
        }
    }

    public void Collect(string title, int id)
    {
        var user = GetUserById(id);
        var role = user?.Role;
        if (role == Role.Customer)
        {
            var bookToLoan = GetBookByTitle(title);
            bookToLoan?.Return(bookToLoan.Title);
        }
        else
        {
            Console.WriteLine($"You need to be a customer to borrow a book");
        }
    }

    public void PrintPages(string title, int startPage, int endPage, int id)
    {
        var user = GetUserById(id);
        var role = user?.Role;
        if (role == Role.Librarian)
        {
            var docToPrint = GetBookByTitle(title);
            docToPrint?.Print(docToPrint.Title, startPage, endPage);
        }
        else
        {
            Console.WriteLine($"Option only for librarians");

        }
    }
    public bool AddBook(Book book, int id)
    {
        var user = GetUserById(id);
        var role = user?.Role;
        if (role == Role.Librarian)
        {
            if (book != null && !Books.ContainsKey(book.Isbn))
            {
                Books.Add(book.Isbn, book);
                Console.WriteLine($"Added '{book.Title}'");

                return true;
            }
        }
        else
        {
            Console.WriteLine($"Option only for librarians");
        }
        return false;
    }

    public void RemoveBook(string isbn, int id)
    {
        var user = GetUserById(id);
        var role = user?.Role;
        if (role == Role.Librarian)
        {
            if (Books.ContainsKey(isbn))
            {
                var bookToRemove = Books[isbn];
                Books.Remove(isbn);
                Console.WriteLine($"'{bookToRemove.Title}' (ISBN: {isbn}) removed from the list");
            }
            else
            {
                Console.WriteLine($"Book with ISBN: '{isbn}' not found");
            }
        }
        else
        {
            Console.WriteLine($"Option only for librarians");
        }
    }

    public void EditBook(string isbn, Book editedBook, int id)
    // int getting oldValue => set value to 0 to specify that not willing to change this value
    {
        var user = GetUserById(id);
        var role = user?.Role;
        if (role == Role.Librarian)
        {
            var bookToUpdate = Books.FirstOrDefault(entry => entry.Value.Isbn == isbn);
            if (bookToUpdate.Value != null)
            {
                Type bookType = bookToUpdate.Value.GetType();
                PropertyInfo[] properties = bookType.GetProperties();
                foreach (var property in properties)
                {
                    PropertyInfo editedBookProperty = editedBook.GetType().GetProperty(property.Name)!;

                    if (editedBookProperty != null)
                    {
                        object value = editedBookProperty.GetValue(editedBook)!;
                        if (value != null)
                        {
                            if (value is string v && string.IsNullOrWhiteSpace(v) || value is int vId && int.Equals(vId, 0))
                            {
                                object oldValue = property.GetValue(bookToUpdate.Value)!;
                                property.SetValue(bookToUpdate.Value, oldValue);
                            }
                            else
                            {
                                property.SetValue(bookToUpdate.Value, value);
                            }
                        }
                        else
                        {
                            object oldValue = property.GetValue(bookToUpdate.Value)!;
                            property.SetValue(bookToUpdate.Value, oldValue);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine($"We coudn't find ISBN:'{isbn}'");
            }
        }
        else
        {
            Console.WriteLine($"Option only for librarians");
        }

    }

    public void PrintBooks()
    {
        if (Books.Count == 0)
        {
            Console.WriteLine("No Books on the list");
        }
        else
        {
            Console.WriteLine("Books List:");
            foreach (var book in Books)
            {
                Console.WriteLine($"{book.Value}");
            }
        }
    }

    // Methods directly related to users
    public void UserInfo(string name, int id)
    {
        var user = GetUserById(id);
        var role = user?.Role;
        if (role == Role.Librarian)
        {
            var userInformation = GetUserByName(name);
            Console.WriteLine($"{userInformation}");
        }
        else
        {
            Console.WriteLine($"Option only for librarians");
        }
    }

    public bool AddUser(User user, int id)
    {
        var userToCheck = GetUserById(id);
        var role = userToCheck?.Role;
        if (role == Role.Librarian)
        {
            if (user != null)
            {
                Users.Add(user);
                Console.WriteLine($"Added '{user.Name}'");

                return true;
            }
        }
        else
        {
            Console.WriteLine($"Option only for librarians");
        }
        return false;
    }

    public void RemoveUser(string name, int id)
    {
        var user = GetUserById(id);
        var role = user?.Role;
        if (role == Role.Librarian)
        {
            var userToRemove = GetUserByName(name);
            if (userToRemove != null)
            {
                Users.Remove(userToRemove);
                Console.WriteLine($"'{userToRemove.Name}' removed from the list");
            }
            else
            {
                Console.WriteLine($"user with title: '{name}' not found ");
            }
        }
        else
        {
            Console.WriteLine($"Option only for librarians");
        }

    }
    public void EditUser(int idToEdit, User editedUser, int id)
    {
        var user = GetUserById(id);
        var role = user?.Role;
        if (role == Role.Librarian)
        {
            var userToUpdate = Users.FirstOrDefault(user => user.Id == idToEdit);
            if (userToUpdate != null)
            {
                Type userType = userToUpdate.GetType();
                PropertyInfo[] properties = userType.GetProperties();
                foreach (var property in properties)
                {
                    PropertyInfo editeduserProperty = editedUser.GetType().GetProperty(property.Name)!;

                    if (editeduserProperty != null)
                    {
                        object value = editeduserProperty.GetValue(editedUser)!;
                        if (value != null)
                        {
                            if (value is string v && string.IsNullOrWhiteSpace(v) || value is int vId && int.Equals(vId, vId))
                            {
                                object oldValue = property.GetValue(userToUpdate)!;
                                property.SetValue(userToUpdate, oldValue);
                            }
                            else
                            {
                                property.SetValue(userToUpdate, value);

                            }
                        }
                        else
                        {
                            object oldValue = property.GetValue(userToUpdate)!;
                            property.SetValue(userToUpdate, oldValue);
                        }

                    }
                }
            }
            else
            {
                Console.WriteLine($"We coudn't find ISBN:'{idToEdit}'");
            }
        }
        else
        {
            Console.WriteLine($"Option only for librarians");

        }
    }

    public User? GetUserById(int id)
    {
        var userFound = Users.Find(user => user.Id == id);
        if (userFound != null)
        {
            return userFound;
        }
        else
        {
            Console.WriteLine($"We don't have this ID: '{id}' in our system");
        }
        return null;
    }

    public User? GetUserByName(string name)
    {
        var userFound = Users.Find(user => user.Name == name);
        if (userFound != null)
        {
            return userFound;
        }
        else
        {
            Console.WriteLine($"We don't have this ID: '{name}' in our system");
        }
        return null;
    }

    public void PrintUsers()
    {
        if (Users.Count == 0)
        {
            Console.WriteLine("No customers yet");
        }
        else
        {
            Console.WriteLine("Customers List:");
            foreach (var user in Users)
            {
                Console.WriteLine($"{user}");
            }
        }
    }
}
