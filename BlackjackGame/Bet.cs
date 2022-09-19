namespace Blackjack;

public class Bet
{
    internal static int bettingAmount = 0;

    internal static bool IsBetValid()
    {
        return bettingAmount <= Player.playerMoney;
    }

    internal static void SetBetAmount()
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("\nHow much you are willing to bet?");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"(You currently have: {Player.playerMoney}$)");
        bettingAmount = int.Parse(Console.ReadLine());
        Console.ForegroundColor = ConsoleColor.White;
    }
}