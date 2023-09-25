public class Address
{
    private string street;
    private string city;
    private string state;
    private string zipCode;

    public Address(string street, string city, string state, string zipCode)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.zipCode = zipCode;
    }

    public string City
    {
        get { return city; }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new InvalidCity("City can't be empty.");
            city = value;
        }
    }

    public string Street
    {
        get { return street; }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new InvalidStreet("Street can't be empty.");
            street = value;
        }
    }

    public string State
    {
        get { return state; }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new InvalidState("State can't be empty.");
            state = value;
        }
    }

    public string ZipCode
    {
        get { return zipCode; }
        set
        {
            if (value.Length > 5)
                throw new InvalidZipCode("Length of zip code can't be bigger than 5");
            zipCode = value;
        }
    }

    public override bool Equals(object obj)
    {
        Address obj2 = obj as Address;
        if (obj == null) return false;
        return (obj2.street == this.street && obj2.city == this.city &&
            obj2.state == this.state && obj2.zipCode == this.zipCode);
    }

    public static bool operator ==(Address address, Address address2)
    {
        if (ReferenceEquals(address, address2)) return true;
        if ((object)address != null) return address.Equals(address2);
        if ((object)address2 != null) return address2.Equals(address);
        return (address.street == address2.street && address.city == address2.city &&
            address.state == address2.state && address.zipCode == address2.zipCode);
    }
    public static bool operator !=(Address address1, Address address2) { return !(address1 == address2); }
}