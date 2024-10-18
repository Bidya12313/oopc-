public class GameAccount
{
    public string UserName { get; set; }

    private int _currentRating;  // Приватне поле для рейтингу
    public int CurrentRating
    {
        get { return _currentRating; }
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

    public int GamesCount { get{return gameHistory.Count;}}
    private List<Game> gameHistory;

    public GameAccount(string userName, int startingRating = 1)
    {
        if (startingRating < 1)
        {
            throw new ArgumentException("Початковий рейтинг не може бути менше 1.");
        }

        UserName = userName;
        CurrentRating = startingRating;
        gameHistory = new List<Game>();
    }

    public void WinGame(string opponentName, int rating)
    {
        if (rating < 0)
        {
            throw new ArgumentException("Рейтинг на який грають не може бути від'ємним.");
        }

        CurrentRating += rating;
        gameHistory.Add(new Game(opponentName, rating, true));
    }

    public void LoseGame(string opponentName, int rating)
    {
        if (rating < 0)
        {
            throw new ArgumentException("Рейтинг на який грають не може бути від'ємним.");
        }

        CurrentRating -= rating;
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
