// GameFactory.cs
public static class GameFactory
{
    public static Game CreateGame(string type, string opponentName, int rating = 0, bool isWin = true)
    {
        return type switch
        {
            "standard" => new StandardGame(opponentName, rating, isWin),
            "training" => new TrainingGame(opponentName),
            "solo" => new SoloRatingGame(opponentName, rating),
            _ => throw new ArgumentException("Невідомий тип гри"),
        };
    }
}
