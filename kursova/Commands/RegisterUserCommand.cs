public class RegisterUserCommand : ICommand
{
    private readonly IUserService _userService;

    public RegisterUserCommand(IUserService userService)
    {
        _userService = userService;
    }

    public void Execute()
    {
        Console.Write("Введіть ім'я користувача: ");
        string userName = Console.ReadLine();

        Console.Write("Введіть початковий баланс: ");
        int balance = int.Parse(Console.ReadLine());

        UserAccount user = new UserAccount(userName, balance);
        _userService.CreateUser(user);
        Console.WriteLine($"Користувач {userName} зареєстрований.");
    }

    public void DisplayOptions()
    {
        Console.WriteLine("Зареєструвати користувача.");
    }
}
