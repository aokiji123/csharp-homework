class Receipt
{
    private List<string> lines = new List<string>();
    private int subtotal = 0;

    public void AddHeader(string storeName, string address)
    {
        lines.Add(storeName);
        lines.Add(address);
        AddSeparator();
    }

    public void AddItem(string name, int quantity, int priceInCents, int discountInCents)
    {
        int itemTotal = (priceInCents - discountInCents) * quantity;
        subtotal += itemTotal;
        string itemLine = $"{name} x {quantity} | {FormatAsDollars(priceInCents)} each | Subtotal: {FormatAsDollars(itemTotal)}";
        lines.Add(itemLine);
    }

    public void AddTotal()
    {
        AddSeparator();
        lines.Add($"TOTAL: {FormatAsDollars(subtotal)}");
    }

    public void AddFooter(string footer)
    {
        AddSeparator();
        lines.Add(footer);
    }

    private void AddSeparator()
    {
        lines.Add(new string('-', 40));
    }

    private string FormatAsDollars(int cents)
    {
        return (cents / 100).ToString() + "." + (cents % 100).ToString("00");
    }

    public void Print()
    {
        foreach (var line in lines)
        {
            Console.WriteLine(line);
        }
    }
}

class Program
{
    static void Main()
    {
        Receipt receipt = new Receipt();
        receipt.AddHeader("Citrus", "Odesa");
        receipt.AddItem("Smartphone 5565L FEST 2/16GB", 1, 15900, 0);
        receipt.AddItem("Smartphone iPhone 15        ", 2, 90000, 0); 
        receipt.AddItem("Smartphone iPhone 14 Pro Max", 1, 85000, 0); 
        receipt.AddItem("Apple Watch 9               ", 1, 45000, 0);
        receipt.AddTotal();
        receipt.AddFooter("Thanks for buying!");
        receipt.Print();
    }
}
