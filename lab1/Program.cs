using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        // Створення об'єктів гравців
        GameAccount player1 = new GameAccount("Player1", 100);
        GameAccount player2 = new GameAccount("Player2", 50);

        // Імітація ігор
        player1.WinGame("Player2", 20);
        player2.LoseGame("Player1", 20);

        player1.LoseGame("Player3", 15);
        player2.WinGame("Player3", 15);

        // Виведення статистики
        player1.GetStats();
        player2.GetStats();
    }
}
