namespace Blackjack;

public class UI
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
            Console.WriteLine($"| Player name: {Player.name}");
            Console.WriteLine($"| Player age: {Player.age}");
            Console.WriteLine($"| Player money: {Player.playerMoney}");
            Console.WriteLine($"| Player favorite card: {Player.favoriteCard}");
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
            Console.WriteLine($"|| {Player.name} {Player.age} ||");
            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.WriteLine($"Hello {Player.name}");
            Console.WriteLine($"{Player.name}, your winnings: {Player.playerMoney}$");
            
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