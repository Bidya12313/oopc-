using System.Collections.Generic;

public class DbContext
{
    public List<GameAccount> Players { get; set; }
    public List<Game> Games { get; set; }

    public DbContext()
    {
        Players = new List<GameAccount>
        {
            new StandardAccount("Player1", 10),
            new SafeAccount("Player2", 10),
            new SafeAccount("Player3", 10)
        };

        Games = new List<Game>();
    } 
}
