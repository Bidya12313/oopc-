public class GameService : IGameService
{
    private readonly IGameRepository _repository;

    public GameService(IGameRepository repository)
    {
        _repository = repository;
    }

    public void RecordGame(Game game) => _repository.AddGame(game);

    public List<Game> GetAllGames() => _repository.GetAllGames();

    public List<Game> GetGamesByPlayer(string userName) =>
        _repository.GetGamesByPlayer(userName);
}
