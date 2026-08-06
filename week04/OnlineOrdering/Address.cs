// Address.cs
// Stores a physical address and knows whether it is in the USA.

class Address
{
    private string _street;
    private string _city;
    private string _stateOrProvince;
    private string _country;

    public Address(string street, string city, string stateOrProvince, string country)
    {
        _street          = street;
        _city            = city;
        _stateOrProvince = stateOrProvince;
        _country         = country;
    }

    // Returns true if this address is in the United States.
    public bool IsInUSA()
    {
        return _country.ToUpper() == "USA";
    }

    // Returns the full address as a formatted multi-line string.
    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_stateOrProvince}\n{_country}";
    }
}
