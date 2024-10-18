using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        // Створення об'єктів гравців
        GameAccount player1 = new GameAccount("Player1", 10);
        GameAccount player2 = new GameAccount("Player2", 10);

        // Імітація ігор
        player1.WinGame((player2.UserName), 20);
        player2.LoseGame(player1.UserName, 20);

        player1.LoseGame(player2.UserName, 15);
        player2.WinGame(player1.UserName, 15);

        // Виведення статистики
        player1.GetStats();
        player2.GetStats();
    }
}
