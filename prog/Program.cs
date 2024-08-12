using System;
using System.Collections.Generic;

public interface IGameLibrary
{
    void DisplayGames();
    string PickRandomGame();
}

public class GameLibrary : IGameLibrary
{
    private List<string> _games;
    private static Random _random = new Random();

    public GameLibrary(string[] gamesArray)
    {
        _games = new List<string>(gamesArray);
    }

    public List<string> Games
    {
        get { return _games; }
        private set { _games = value; }
    }

    public void DisplayGames()
    {
        Console.WriteLine("Your Game Library:");
        for (int i = 0; i < _games.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_games[i]}");
        }
    }

    public string PickRandomGame()
    {
        int randomIndex = _random.Next(_games.Count);
        return _games[randomIndex];
    }
}

public class Program
{
    private enum Games
    {
        TheWitcher3,
        Cyberpunk2077,
        RedDeadRedemption2,
        Minecraft,
        StardewValley,
        Overwatch,
        LeagueOfLegends
    }

    public static void Main()
    {
        string[] gamesArray = Enum.GetNames(typeof(Games));
        GameLibrary library = new GameLibrary(gamesArray);

        library.DisplayGames();
        string randomGame = library.PickRandomGame();

        Console.WriteLine("\nYou should play: " + randomGame);
    }
}

