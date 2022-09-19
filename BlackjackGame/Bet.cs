
namespace BlackjackGame;

public static class Bet
{
    internal static int BettingAmount;

    internal static bool IsBetValid()
    {
        return BettingAmount <= Player.PlayerMoney;
    }

    internal static void SetBetAmount()
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("\nHow much you are willing to bet?");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"(You currently have: {Player.PlayerMoney}$)");
        BettingAmount = int.Parse(Console.ReadLine()!);
        Console.ForegroundColor = ConsoleColor.White;
    }
}