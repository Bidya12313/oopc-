// GameAccount.cs
using System;
using System.Collections.Generic;

public abstract class GameAccount
{
    public string UserName { get; set; }
    protected int _currentRating;
    public int CurrentRating
    {
        get => _currentRating;
        set
        {
            if (value < 1)  // Перевірка на те, що рейтинг не менший за 1
            {
                _currentRating = 1;
            }
            else
                _currentRating = value;
        }
    }
    protected List<Game> gameHistory;

    public int GamesCount => gameHistory.Count;

    protected GameAccount(string userName, int startingRating = 1)
    {
        if (startingRating < 1) 
            throw new ArgumentException("Початковий рейтинг не може бути менше 1.");

        UserName = userName;
        CurrentRating = startingRating;
        gameHistory = new List<Game>();
    }

    // Віртуальні методи для різних типів облікових записів
    public virtual void WinGame(Game game)
    {
        CurrentRating += game.CalculateRating();
        gameHistory.Add(game);
    }

    public virtual void LoseGame(Game game)
    {
        CurrentRating -= game.CalculateRating();
        CurrentRating = Math.Max(CurrentRating, 1);
        gameHistory.Add(game);
    }

    public void GetStats()
    {
        Console.WriteLine($"Статистика для гравця: {UserName}");
        Console.WriteLine("Ігри:");
        Console.WriteLine("Індекс | Опонент | Результат | Рейтинг");

        foreach (var game in gameHistory)
        {
            string result = game.IsWin ? "Перемога" : "Поразка";
            Console.WriteLine($"{game.GameId} | {game.OpponentName} | {result} | {game.Rating}");
        }

        Console.WriteLine($"Поточний рейтинг: {CurrentRating}");
        Console.WriteLine($"Кількість зіграних ігор: {GamesCount}\n");
    }
}

// Клас для стандартного облікового запису
public class StandardAccount : GameAccount
{
    public StandardAccount(string userName, int startingRating = 1)
        : base(userName, startingRating) { }
}

// Гравець з меншими втратами при поразці
public class SafeAccount : GameAccount
{
    public SafeAccount(string userName, int startingRating = 1)
        : base(userName, startingRating) { }

    public override void LoseGame(Game game)
    {
        CurrentRating -= game.CalculateRating() / 2;  // Менше втрачає при поразці
        CurrentRating = Math.Max(CurrentRating, 1);
        gameHistory.Add(game);
    }
}


