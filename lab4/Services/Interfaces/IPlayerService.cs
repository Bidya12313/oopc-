using System.Collections.Generic;

public interface IPlayerService
{
    void CreatePlayer(GameAccount player);
    GameAccount GetPlayer(string userName);
    List<GameAccount> GetAllPlayers();
    void DeletePlayer(string userName);
}
