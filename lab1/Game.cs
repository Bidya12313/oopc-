using System;

public class Game
{
    private static int idCounter = 0;
    public int GameId { get; set; }
    public string OpponentName { get; set; }
    public int Rating { get; set; }
    public bool IsWin { get; set; }

    public Game(string opponentName, int rating, bool isWin)
    {
        if (rating < 0)
        {
            throw new ArgumentException("Рейтинг на який грають не може бути від'ємним.");
        }
        
        GameId = ++idCounter;
        OpponentName = opponentName;
        Rating = rating;
        IsWin = isWin;
    }
}
