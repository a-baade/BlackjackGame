
namespace BlackjackGame;

public static class Ui
{
    internal static void PrintCredits()
        {
            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }

      internal static void PrintStats()
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"| Player name: {Player.Name}");
            Console.WriteLine($"| Player age: {Player.Age}");
            Console.WriteLine($"| Player money: {Player.PlayerMoney}");
            Console.WriteLine($"| Player favorite card: {Player.FavoriteCard}");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }
    internal static void PrintMenu()
        {
            Console.WriteLine("1. New round");
            Console.WriteLine("2. Reset stats");
            Console.WriteLine("3. Stats");
            Console.WriteLine("4. Credits");
            Console.WriteLine("5. Exit");
        }
    internal static void PrintPlayerMenuInfo()
        {
            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.WriteLine($"|| {Player.Name} {Player.Age} ||");
            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.WriteLine($"Hello {Player.Name}");
            Console.WriteLine($"{Player.Name}, your winnings: {Player.PlayerMoney}$");
            
        }
    internal static void PrintLogo()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("/.-----------/||");
            Console.WriteLine("| ♥       ♥  |||");
            Console.WriteLine("| BlackJack  |||");
            Console.WriteLine("|            |||");
            Console.WriteLine("|     ♥      |||");
            Console.WriteLine("|            |||");
            Console.WriteLine("|             |||");
            Console.WriteLine("| ♥       ♥  ||/");
            Console.WriteLine("\\-----------./  ");
            Console.WriteLine("");
            Console.ResetColor();
        }
}