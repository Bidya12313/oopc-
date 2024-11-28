using System.Collections.Generic;

public interface IGameRepository
{
    void AddGame(Game game);
    Game GetGameById(int gameId);
    List<Game> GetAllGames();
    List<Game> GetGamesByPlayer(string userName);
}
