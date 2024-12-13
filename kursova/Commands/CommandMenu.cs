public class CommandMenu
{
    private readonly Dictionary<string, ICommand> _commands;

    public CommandMenu(Dictionary<string, ICommand> commands)
    {
        _commands = commands;
    }

    public void DisplayMenu()
    {
        Console.WriteLine("Оберіть опцію:");
        foreach (var command in _commands)
        {
            Console.WriteLine($"{command.Key}. {command.Value.GetType().Name.Replace("Command", "")}");
        }
        Console.WriteLine("5. Вихід");
    }

    public void ExecuteCommand(string option)
    {
        if (_commands.ContainsKey(option))
        {
            _commands[option].Execute();
        }
        else
        {
            Console.WriteLine("Невірна опція. Спробуйте ще раз.");
        }
    }
}
