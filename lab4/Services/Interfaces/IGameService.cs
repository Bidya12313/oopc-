using System.Collections.Generic;

public interface IGameService
{
    void RecordGame(Game game);
    List<Game> GetAllGames();
    List<Game> GetGamesByPlayer(string userName);
}
