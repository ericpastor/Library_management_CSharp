namespace UsersManagement;

public class Librarian : User
{
    public Librarian(string name) : base(name, Role.Librarian)
    { }

    public override string ToString()
    {
        return $"Name: {Name}\n Role:{Role.Librarian}\n ID:{id}\n";
    }
}

