class Program
{
    static void Main()
    {
        HashTable<string, int> hashTable = new HashTable<string, int>();

        hashTable.Add("one", 1);
        hashTable.Add("two", 2);
        hashTable.Add("three", 3);

        Console.WriteLine("Key value of 'one': " + hashTable.Get("one"));
        Console.WriteLine("Key value of 'two': " + hashTable.Get("two"));
        Console.WriteLine("Key value of 'three': " + hashTable.Get("three"));

        try
        {
            hashTable.Add("one", 10);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        hashTable.Remove("two");
        Console.WriteLine("After deleting 'two':");
        try
        {
            Console.WriteLine("Key value of 'two': " + hashTable.Get("two"));
        }
        catch (KeyNotFoundException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
