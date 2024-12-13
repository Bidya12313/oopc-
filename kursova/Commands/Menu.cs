public class Menu
{
    private readonly Dictionary<string, ICommand> _commands;

    public Menu(Dictionary<string, ICommand> commands)
    {
        _commands = commands;
    }

    public void DisplayMenu()
    {
        Console.WriteLine("Оберіть опцію:");

        foreach (var command in _commands)
        {
            Console.WriteLine($"{command.Key}. {GetCommandDescription(command.Value)}");
        }

        Console.WriteLine("6. Вихід");
    }

    private string GetCommandDescription(ICommand command)
    {
        if (command is DisplayProductsCommand)
        {
            return "Відобразити товари";
        }
        else if (command is RegisterUserCommand)
        {
            return "Зареєструвати користувача";
        }
        else if (command is AddBalanceCommand)
        {
            return "Поповнити баланс";
        }
        else if (command is MakePurchaseCommand)
        {
            return "Купити товар";
        }
        else if (command is AddProductCommand)
        {
            return "Додати товар";
        }
        else
        {
            return "Невідома команда";
        }
    }

    public void ExecuteCommand(string option)
    {
        if (_commands.ContainsKey(option))
        {
            var command = _commands[option];
            command.DisplayOptions();
            command.Execute();
        }
        else
        {
            Console.WriteLine("Невірна опція. Спробуйте ще раз.");
        }
    }
}
