public class AddBalanceCommand : ICommand
{
    private readonly IUserService _userService;

    public AddBalanceCommand(IUserService userService)
    {
        _userService = userService;
    }

    public void Execute()
    {
        Console.Write("Введіть ім'я користувача: ");
        string userName = Console.ReadLine();

        Console.Write("Введіть суму для поповнення: ");
        int amount = int.Parse(Console.ReadLine());

        _userService.AddBalance(userName, amount);
        Console.WriteLine($"Баланс користувача {userName} поповнено на {amount}.");
    }

    public void DisplayOptions()
    {
        Console.WriteLine("Поповнити баланс.");
    }
}
