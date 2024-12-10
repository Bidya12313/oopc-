public class AddPlayerCommand : ICommand
{
    private readonly IPlayerService _playerService;

    public AddPlayerCommand(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    public void Execute()
    {
        Console.Write("Введіть ім'я гравця: ");
        string userName = Console.ReadLine();

        Console.Write("Введіть тип акаунта (standard/safe): ");
        string accountType = Console.ReadLine();

        GameAccount player = accountType switch
        {
            "standard" => new StandardAccount(userName),
            "safe" => new SafeAccount(userName),
            _ => throw new ArgumentException("Невірний тип акаунта")
        };

        _playerService.CreatePlayer(player);
        Console.WriteLine($"Гравець {userName} доданий.");
    }

    public void DisplayOptions()
    {
        Console.WriteLine("Додати нового гравця.");
    }
}
