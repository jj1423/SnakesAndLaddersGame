using SnakesAndLadders.Core;
using SnakesAndLadders.Entities;
using SnakesAndLadders.Services;

Console.WriteLine("Welcome to the snakes and ladders game!");
List<Player> players = new List<Player>();

while(true)
{
    Console.WriteLine("Introduce a player name or press enter key to start the game:");
    var input = Console.ReadLine();
    if (string.IsNullOrEmpty(input))
    {
        if (players.Count() > 0)
        {
            break;
        }
        else
        {
            Console.WriteLine("There is no players, introduce at least one valid player name.");
            continue;
        }
    }

    players.Add(new Player(input));
}

// The dice service could be injected with a framework but for this case it is not necessary
SnakesAndLaddersGame game = new SnakesAndLaddersGame(players, new SixFacesDiceService());
Console.WriteLine("The game has started!");

while (true)
{
    Console.WriteLine($"Player {game.CurrentPlayerName}, press any key to roll the dice.");
    Console.ReadLine();

    var result = game.PlayRound();
    Console.WriteLine($"Dice score is {result.RollDiceScore} and your new token position is {result.Player.TokenPosition}.");
    Console.WriteLine();

    if (result.HasWonTheGame)
    {
        Console.WriteLine($"Congratulation player {result.Player.Name}, you has won the game!!!");
        break;
    }
}
