public class Program
{
    static void Main()
    {
        DbContext dbContext = new DbContext();
        IPlayerRepository playerRepo = new PlayerRepository(dbContext);
        IGameRepository gameRepo = new GameRepository(dbContext);
        IPlayerService playerService = new PlayerService(playerRepo);
        IGameService gameService = new GameService(gameRepo, playerRepo);

        // Створюємо нові ігри
        var game1 = new StandardGame("Player1", 50, true);
        var game2 = new TrainingGame("Player2");
        var game3 = new SoloRatingGame("Player3", 30);

        // Додаємо ігри через сервіс
        gameService.RecordGame(game1);
        gameService.RecordGame(game2);
        gameService.RecordGame(game3);

        // Виводимо статистику для кожного гравця
        foreach (var player in playerService.GetAllPlayers())
        {
            player.GetStats();
        }
    }
}
