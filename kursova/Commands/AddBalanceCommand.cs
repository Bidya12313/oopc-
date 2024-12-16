public class AddBalanceCommand : ICommand
{
    private readonly IUserService _userService;

    public AddBalanceCommand(IUserService userService)
    {
        _userService = userService;
    }

    public void Execute()
    {
        if (Program.loggedInUser == null)
        {
            Console.WriteLine("Будь ласка, увійдіть в систему для покупки.");
            return;
        }

        string userName = Program.loggedInUser.UserName;
        
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
