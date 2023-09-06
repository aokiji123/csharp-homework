public class InvalidCity : Exception
{
    public InvalidCity(string message) : base(message) { }
}

public class InvalidStreet : Exception
{
    public InvalidStreet(string message) : base(message) { }
}

public class InvalidState : Exception
{
    public InvalidState(string message) : base(message) { }
}

public class InvalidZipCode : Exception
{
    public InvalidZipCode(string message) : base(message) { }
}
