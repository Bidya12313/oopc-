using System.Collections.Generic;

public interface IPlayerRepository
{
    void AddPlayer(GameAccount player);
    GameAccount GetPlayerByName(string userName);
    List<GameAccount> GetAllPlayers();
    void UpdatePlayer(GameAccount player);
    void DeletePlayer(string userName);
}
