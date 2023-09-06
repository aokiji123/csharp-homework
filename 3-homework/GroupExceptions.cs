public class InvalidGroup : Exception
{
    public InvalidGroup(string message) : base(message) { }
}

public class InvalidGroupType : Exception
{
    public InvalidGroupType(string message) : base(message) { }
}

public class InvalidGroupForTransfer : Exception
{
    public InvalidGroupForTransfer(string message) : base(message) { }
}

public class InvalidGroupForReplace : Exception
{
    public InvalidGroupForReplace(string message) : base(message) { }
}