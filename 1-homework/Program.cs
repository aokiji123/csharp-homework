class Program
{
    static void Main()
    {
        // 1)
        Console.Write("Enter first number: ");
        double number1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter second number: ");
        double number2 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter third number: ");
        double number3 = Convert.ToDouble(Console.ReadLine());

        double average = (number1 + number2 + number3) / 3;

        Console.WriteLine($"Average: {average}");

        // 2)
        Console.Write("Enter number: ");
        double degreeNumber = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter degree: ");
        double degree = Convert.ToDouble(Console.ReadLine());

        double result = Math.Pow(degreeNumber, degree);

        Console.WriteLine($"Result: {result}");

        // 3)
        Console.Write("Enter number in UAH: ");
        double moneyInUah = Convert.ToDouble(Console.ReadLine());

        double moneyInUsd = moneyInUah * 0.027;
        double moneyInEuro = moneyInUah * 0.025;

        Console.WriteLine($"Money in USD: {moneyInUsd}");
        Console.WriteLine($"Money in Euro: {moneyInEuro}");

        // 4)
        Console.Write("Enter number of km: ");
        double km = Convert.ToDouble(Console.ReadLine());

        double kmToMiles = km * 0.621371;
        double kmToSeaMiles = km * 0.539957;

        Console.WriteLine($"Km to Miles: {kmToMiles}");
        Console.WriteLine($"Km to Sea Miles: {kmToSeaMiles}");

        // 5)
        Console.Write("Enter number: ");
        double numberToFindPercent = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter percent: ");
        double percent = Convert.ToDouble(Console.ReadLine());

        double percentResult = numberToFindPercent * percent / 100;
        Console.WriteLine($"Result: {percentResult}");

        // 6)
        Console.Write("What do you want to do (1 for celsius, 2 for fahrenheit: ");
        double choice = Convert.ToDouble(Console.ReadLine());
        if (choice == 1)
        {
            Console.Write("Enter celsius to convert them to fahrenheit: ");
            double celsiusToFahrenheit = Convert.ToDouble(Console.ReadLine());
            double fahrenheit = (celsiusToFahrenheit * 9 / 5) + 32;
            Console.WriteLine($"Result: {fahrenheit}");
        }
        else if (choice == 2)
        {
            Console.Write("Enter fahrenheit to convert them to celsius: ");
            double fahrenheitToCelsius = Convert.ToDouble(Console.ReadLine());
            double celsius = (fahrenheitToCelsius - 32) * 5 / 9;
            Console.WriteLine($"Result: {celsius}");
        }
        else
        {
            throw new Exception("Error");
        }

    }
}