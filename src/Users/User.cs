namespace UsersManagement;

public enum Role
{
    Customer,
    Librarian
}

public class User
{
    private static int _lastId = 0;

    static int GenerateId()
    {
        return Interlocked.Increment(ref _lastId);
    }

    public int id = GenerateId();

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public string Name { get; set; }
    public Role Role { get; protected set; }

    public User(string name, Role role)
    {
        this.Id = id;
        this.Name = name;
        this.Role = role;
    }
}
