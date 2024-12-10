public class ShowPlayerStatsCommand : ICommand
{
    private readonly IPlayerService _playerService;

    public ShowPlayerStatsCommand(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    public void Execute()
    {
        Console.Write("Введіть ім'я гравця для перегляду статистики: ");
        string userName = Console.ReadLine();
        var player = _playerService.GetPlayer(userName);

        if (player != null)
        {
            player.GetStats();
        }
        else
        {
            Console.WriteLine("Гравець не знайдений.");
        }
    }

    public void DisplayOptions()
    {
        Console.WriteLine("Показати статистику гравця.");
    }
}
