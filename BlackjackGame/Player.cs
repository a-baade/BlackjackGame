namespace Blackjack;

public class Player
{
    const double initialMoney = 100.00;

    internal static double playerMoney = initialMoney;
    internal static string name = "Unnamed";
    internal static int age = 0;
    internal static string favoriteCard = "Ace of Spades";
    static int totalGamesPlayed = 0;

    public static int currentWinningStreak = 0;
    public static int bestWinningStreak = 0;

    internal static void ResetPlayerStats()
    {
        totalGamesPlayed = 0;
        currentWinningStreak = 0;
        bestWinningStreak = 0;
        playerMoney = initialMoney;

        Console.WriteLine("Stats. reset");
        Console.WriteLine("Press any key to continue..");
        Console.ReadKey();
    }
    internal static void SetInitialPlayerInformation(bool setDefaultValues = false)
    {
        if(!setDefaultValues)
        {
            Console.WriteLine("Please insert your name and press <Enter>:");
            name = Console.ReadLine();

            Console.WriteLine("Please insert your age and press <Enter>:");
            age = int.Parse(Console.ReadLine());
                
        }
        else
        {
            name = "Andreas";
            age = 24;
        }
    }
}