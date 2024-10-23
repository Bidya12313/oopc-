// Program.cs
using System;

class Program
{
    static void Main(string[] args)
    {
        // Створення гравців різних типів
        GameAccount player1 = new StandardAccount("Player1", 10);
        GameAccount player2 = new SafeAccount("Player2", 10);
        GameAccount player3 = new SafeAccount("Player3", 10);

        // Імітація ігор
        Game game1 = GameFactory.CreateGame("standard", player2.UserName, 20, true);
        player1.WinGame(game1);
        player2.LoseGame(game1);

        Game game2 = GameFactory.CreateGame("solo", player1.UserName, 15);
        player3.WinGame(game2);

        Game game3 = GameFactory.CreateGame("training", player3.UserName);
        player2.LoseGame(game3);

        // Виведення статистики
        player1.GetStats();
        player2.GetStats();
        player3.GetStats();
    }
}
