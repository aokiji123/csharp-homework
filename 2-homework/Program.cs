class Program
{
    static string[] bigNumbers = {
        "  000  \n 0   0 \n0     0\n0     0\n 0   0 \n  000  ",
        "   1   \n  11   \n   1   \n   1   \n   1   \n 11111 ",
        "  222  \n 2   2 \n    2  \n   2   \n 2     \n 22222 ",
        "  333  \n 3   3 \n     3 \n   33  \n     3 \n  333  ",
        "    4  \n   44  \n  4 4  \n 4  4  \n 44444 \n    4  ",
        " 55555 \n 5     \n 5555  \n     5 \n 5   5 \n  555  ",
        "  666  \n 6     \n 6666  \n 6   6 \n 6   6 \n  666  ",
        " 77777 \n     7 \n    7  \n   7   \n  7    \n 7     ",
        "  888  \n 8   8 \n  888  \n 8   8 \n 8   8 \n  888  ",
        "  9999 \n 9   9 \n  9999 \n     9 \n    9  \n  999  "
    };

    static void PrintBigNumber(string number)
    {
        foreach (char digit in number)
        {
            if (char.IsDigit(digit))
            {
                int digitValue = int.Parse(digit.ToString());
                Console.WriteLine(bigNumbers[digitValue]);
            }
        }
    }

    static void Main()
    {
        Console.Write("Введите число: ");
        string inputNumber = Console.ReadLine();
        PrintBigNumber(inputNumber);
    }
}
