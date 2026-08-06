// Customer.cs
// Stores a customer's name and address.

class Customer
{
    private string  _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name    = name;
        _address = address;
    }

    public string Name
    {
        get { return _name; }
    }

    public Address Address
    {
        get { return _address; }
    }

    // Returns true if the customer lives in the USA.
    public bool LivesInUSA()
    {
        return _address.IsInUSA();
    }
}
