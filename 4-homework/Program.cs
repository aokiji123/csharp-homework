class Program
{
    delegate void MenuDelegate();

    static void Main()
    {
        MenuDelegate menuItems = NewGame;
        menuItems += LoadGame;
        menuItems += ShowRules;
        menuItems += ShowAuthor;
        menuItems += Exit;

        while (true)
        {
            DisplayMenu();

            int choice = GetMenuChoice();

            Delegate[] menuItemsList = menuItems.GetInvocationList();

            if (choice > 0 && choice < menuItemsList.Length)
            {
                MenuDelegate option = (MenuDelegate)menuItemsList[choice - 1];

                option.Invoke();
            }
            else if (choice == 0)
                break;
            else
            {
                Console.WriteLine("Недопустимый выбор. Попробуйте снова.");
            }
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("Меню:");
        Console.WriteLine("1 - Новая игра");
        Console.WriteLine("2 - Загрузить игру");
        Console.WriteLine("3 - Правила");
        Console.WriteLine("4 - Об авторе");
        Console.WriteLine("0 - Выход");
    }

    static int GetMenuChoice()
    {
        Console.Write("Выберите пункт меню: ");
        string input = Console.ReadLine();
        int choice;

        if (!int.TryParse(input, out choice))
        {
            Console.WriteLine("Введите корректное число.");
            return -1;
        }

        return choice;
    }

    static void NewGame()
    {
        Console.WriteLine("Начата новая игра.");
    }

    static void LoadGame()
    {
        Console.WriteLine("Игра загружена.");
    }

    static void ShowRules()
    {
        Console.WriteLine("Показываю правила игры.");
    }

    static void ShowAuthor()
    {
        Console.WriteLine("Информация об авторе.");
    }

    static void Exit()
    {
        Console.WriteLine("Выход из программы.");
    }
}