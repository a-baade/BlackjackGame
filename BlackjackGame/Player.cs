
namespace BlackjackGame;

public static class Player
{
    private const double InitialMoney = 100.00;

    internal static double PlayerMoney = InitialMoney;
    internal static string? Name = "Unnamed";
    internal static int Age;
    internal const string FavoriteCard = "Ace of Spades";

    public static int CurrentWinningStreak;
    public static int BestWinningStreak;

    internal static void ResetPlayerStats()
    {
        CurrentWinningStreak = 0;
        BestWinningStreak = 0;
        PlayerMoney = InitialMoney;

        Console.WriteLine("Stats. reset");
        Console.WriteLine("Press any key to continue..");
        Console.ReadKey();
    }
    internal static void SetInitialPlayerInformation(bool setDefaultValues = false)
    {
        if(!setDefaultValues)
        {
            Console.WriteLine("Please insert your name and press <Enter>:");
            Name = Console.ReadLine();

            Console.WriteLine("Please insert your age and press <Enter>:");
            Age = int.Parse(Console.ReadLine()!);
                
        }
        else
        {
            Name = "Andreas";
            Age = 24;
        }
    }
}