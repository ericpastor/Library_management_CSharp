namespace UsersManagement;

public class Customer : User
{
    public Customer(string name) : base(name, Role.Customer)
    { }

    public override string ToString()
    {
        return $"Name: {Name}\n Role:{Role.Customer}\n ID:{id}\n";
    }
}
