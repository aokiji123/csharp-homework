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
}