using System.Linq;

public class GameRepository : IGameRepository
{
    private readonly DbContext _context;

    public GameRepository(DbContext context)
    {
        _context = context;
    }

    public void AddGame(Game game) => _context.Games.Add(game);

    public Game GetGameById(int gameId) =>
        _context.Games.FirstOrDefault(g => g.GameId == gameId);

    public List<Game> GetAllGames() => _context.Games;

    public List<Game> GetGamesByPlayer(string userName) =>
        _context.Games.Where(g => g.OpponentName == userName).ToList();
}
