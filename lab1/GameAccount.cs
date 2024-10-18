using System;
using System.Collections.Generic;

public class GameAccount
{
    public string UserName { get; set; }
    public int CurrentRating { get; set; }
    public int GamesCount { get; set; }
    private List<Game> gameHistory;

    public GameAccount(string userName, int startingRating = 1)
    {
        if (startingRating < 1)
        {
            throw new ArgumentException("Початковий рейтинг не може бути менше 1.");
        }

        UserName = userName;
        CurrentRating = startingRating;
        GamesCount = 0;
        gameHistory = new List<Game>();
    }

    public void WinGame(string opponentName, int rating)
    {
        if (rating < 0)
        {
            throw new ArgumentException("Рейтинг на який грають не може бути від'ємним.");
        }
        
        CurrentRating += rating;
        GamesCount++;
        gameHistory.Add(new Game(opponentName, rating, true));
    }

    public void LoseGame(string opponentName, int rating)
    {
        if (rating < 0)
        {
            throw new ArgumentException("Рейтинг на який грають не може бути від'ємним.");
        }

        CurrentRating -= rating;
        if (CurrentRating < 1)
        {
            CurrentRating = 1;
        }

        GamesCount++;
        gameHistory.Add(new Game(opponentName, rating, false));
    }

    public void GetStats()
    {
        Console.WriteLine($"Статистика для гравця: {UserName}");
        Console.WriteLine("Ігри:");
        Console.WriteLine("Індекс | Опонент | Результат | Рейтинг");

        for (int i = 0; i < gameHistory.Count; i++)
        {
            var game = gameHistory[i];
            string result = game.IsWin ? "Перемога" : "Поразка";
            Console.WriteLine($"{game.GameId} | {game.OpponentName} | {result} | {game.Rating}");
        }

        Console.WriteLine($"Поточний рейтинг: {CurrentRating}");
        Console.WriteLine($"Кількість зіграних ігор: {GamesCount}");
        Console.WriteLine();
    }
}
