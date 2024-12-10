public class DisplayPlayersCommand : ICommand
{
    private readonly IPlayerService _playerService;

    public DisplayPlayersCommand(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    public void Execute()
    {
        var players = _playerService.GetAllPlayers();
        foreach (var player in players)
        {
            Console.WriteLine($"Ім'я: {player.UserName}, Рейтинг: {player.CurrentRating}");
        }
    }

    public void DisplayOptions()
    {
        Console.WriteLine("Показати всіх гравців.");
    }
}
