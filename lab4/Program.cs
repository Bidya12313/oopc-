public class Program
{
    static void Main()
    {
        DbContext dbContext = new DbContext();
        IPlayerRepository playerRepo = new PlayerRepository(dbContext);
        IGameRepository gameRepo = new GameRepository(dbContext);
        IPlayerService playerService = new PlayerService(playerRepo);
        IGameService gameService = new GameService(gameRepo, playerRepo);

        // Створення команд
        ICommand displayPlayers = new DisplayPlayersCommand(playerService);
        ICommand addPlayer = new AddPlayerCommand(playerService);
        ICommand showStats = new ShowPlayerStatsCommand(playerService);
        ICommand playGame = new PlayGameCommand(gameService);

        // Словник команд
        Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>
        {
            { "1", displayPlayers },
            { "2", addPlayer },
            { "3", showStats },
            { "4", playGame }
        };

        // Цикл меню
        while (true)
        {
            Console.WriteLine("Оберіть опцію:");
            Console.WriteLine("1. Показати всіх гравців");
            Console.WriteLine("2. Додати нового гравця");
            Console.WriteLine("3. Показати статистику гравця");
            Console.WriteLine("4. Розпочати нову гру");
            Console.WriteLine("5. Вихід");

            string option = Console.ReadLine();

            if (option == "5") break;

            if (commands.ContainsKey(option))
            {
                commands[option].DisplayOptions();
                commands[option].Execute();
            }
            else
            {
                Console.WriteLine("Невірна опція. Спробуйте ще раз.");
            }
        }
    }
}
