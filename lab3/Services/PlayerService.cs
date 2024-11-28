public class PlayerService : IPlayerService
{
    private readonly IPlayerRepository _repository;

    public PlayerService(IPlayerRepository repository)
    {
        _repository = repository;
    }

    public void CreatePlayer(GameAccount player) => _repository.AddPlayer(player);

    public GameAccount GetPlayer(string userName) => _repository.GetPlayerByName(userName);

    public List<GameAccount> GetAllPlayers() => _repository.GetAllPlayers();

    public void DeletePlayer(string userName) => _repository.DeletePlayer(userName);
}
