using System.Linq;

public class PlayerRepository : IPlayerRepository
{
    private readonly DbContext _context;

    public PlayerRepository(DbContext context)
    {
        _context = context;
    }

    public void AddPlayer(GameAccount player) => _context.Players.Add(player);

    public GameAccount GetPlayerByName(string userName) =>
        _context.Players.FirstOrDefault(p => p.UserName == userName);

    public List<GameAccount> GetAllPlayers() => _context.Players;

    public void UpdatePlayer(GameAccount player)
    {
        var existingPlayer = GetPlayerByName(player.UserName);
        if (existingPlayer != null)
        {
            _context.Players.Remove(existingPlayer);
            _context.Players.Add(player);
        }
    }

    public void DeletePlayer(string userName)
    {
        var player = GetPlayerByName(userName);
        if (player != null)
            _context.Players.Remove(player);
    }
}
