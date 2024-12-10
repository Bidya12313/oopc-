public class PlayGameCommand : ICommand
{
    private readonly IGameService _gameService;

    public PlayGameCommand(IGameService gameService)
    {
        _gameService = gameService;
    }

    public void Execute()
    {
        Console.Write("Введіть ім'я першого гравця: ");
        string player1Name = Console.ReadLine();

        Console.Write("Введіть ім'я другого гравця: ");
        string player2Name = Console.ReadLine();

        Console.Write("Введіть тип гри (standard/training/solo): ");
        string gameType = Console.ReadLine();

        Console.Write("Введіть рейтинг: ");
        int rating = int.Parse(Console.ReadLine());

        Game game = GameFactory.CreateGame(gameType, player2Name, rating);
        _gameService.RecordGame(game);
        Console.WriteLine("Гра зафіксована.");
    }

    public void DisplayOptions()
    {
        Console.WriteLine("Розпочати нову гру.");
    }
}
