public class LoginCommand : ICommand
{
    private readonly IUserService _userService;
    public LoginCommand(IUserService userService)
    {
        _userService = userService;
    }

    public void Execute()
    {
        Console.Write("Введіть ім'я користувача: ");
        string username = Console.ReadLine();

        Console.Write("Введіть пароль: ");
        string password = Console.ReadLine();

        var user = _userService.Authenticate(username, password);

        if (user != null)
        {
            Program.loggedInUser = user;
            Console.WriteLine($"Вхід виконано успішно. Ласкаво просимо, {user.UserName}!");
        }
        else
        {
            Console.WriteLine("Невірне ім'я користувача або пароль. Спробуйте ще раз.");
        }
    }

    public void DisplayOptions()
    {
        Console.WriteLine("Логін");
    }
}
