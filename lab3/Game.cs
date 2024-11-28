// Game.cs
using System;

public abstract class Game
{
    private static int idCounter = 0;
    public int GameId { get; }
    public string OpponentName { get; }
    public int Rating { get; }
    public bool IsWin { get; }

    protected Game(string opponentName, int rating, bool isWin)
    {
        if (rating < 0) 
            throw new ArgumentException("Рейтинг на який грають не може бути від'ємним.");

        GameId = ++idCounter;
        OpponentName = opponentName;
        Rating = rating;
        IsWin = isWin;
    }

    public abstract int CalculateRating();
}

// Стандартна гра
public class StandardGame : Game
{
    public StandardGame(string opponentName, int rating, bool isWin)
        : base(opponentName, rating, isWin) { }

    public override int CalculateRating() => Rating;
}

// Тренувальна гра (без рейтингу)
public class TrainingGame : Game
{
    public TrainingGame(string opponentName) 
        : base(opponentName, 0, true) { }

    public override int CalculateRating() => 0;
}

// Гра, де тільки один гравець отримує рейтинг
public class SoloRatingGame : Game
{
    public SoloRatingGame(string opponentName, int rating) 
        : base(opponentName, rating, true) { }

    public override int CalculateRating() => Rating;
}
