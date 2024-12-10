public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;
    private readonly IPlayerRepository _playerRepository;

    public GameService(IGameRepository gameRepository, IPlayerRepository playerRepository)
    {
        _gameRepository = gameRepository;
        _playerRepository = playerRepository;
    }

    public void RecordGame(Game game)
    {
        // Додаємо гру до репозиторію ігор
        _gameRepository.AddGame(game);

        // Оновлюємо статистику гравця
        var player = _playerRepository.GetPlayerByName(game.OpponentName);
        if (player == null)
            throw new Exception($"Гравець {game.OpponentName} не знайдений.");

        if (game.IsWin)
            player.WinGame(game);
        else
            player.LoseGame(game);

        _playerRepository.UpdatePlayer(player);
    }

    public List<Game> GetAllGames() => _gameRepository.GetAllGames();

    public List<Game> GetGamesByPlayer(string userName) =>
        _gameRepository.GetGamesByPlayer(userName);
}
