using System;

class Program
{
    static void Main(string[] args)
    {
        DbContext dbContext = new DbContext();
        IPlayerRepository playerRepo = new PlayerRepository(dbContext);
        IGameRepository gameRepo = new GameRepository(dbContext);
        IPlayerService playerService = new PlayerService(playerRepo);
        IGameService gameService = new GameService(gameRepo);

        // Виведення списку гравців
        Console.WriteLine("Список гравців:");
        foreach (var player in playerService.GetAllPlayers())
        {
            Console.WriteLine($"Гравець: {player.UserName}, Рейтинг: {player.CurrentRating}");
        }

        // Виведення списку ігор
        Console.WriteLine("\nСписок ігор:");
        foreach (var g in gameService.GetAllGames())
        {
            Console.WriteLine($"Гра {g.GameId}: Опонент: {g.OpponentName}, Рейтинг: {g.Rating}, Результат: {(g.IsWin ? "Перемога" : "Поразка")}");
        }
    }
}
