namespace Blackjack;

public class Game
{
    
    internal static void HandleGame()
        {
            Console.WriteLine("\nType in menu option number and press <Enter>");
            string selectedMenuOption = Console.ReadLine();

            switch (selectedMenuOption)
            {
                case "1":
                    Round.HandleNewRound();
                    break;
                case "2":
                    Console.WriteLine("Are you sure you want to reset your stat?\n1. Yes\n2. No");
                    string promptAnswer = Console.ReadLine();
                    if (promptAnswer == "1")
                    {
                        Player.ResetPlayerStats();
                    }
                    break;
                case "3":
                    UI.PrintStats();
                    break;
                case "4":
                    UI.PrintCredits();
                    break;
                case "5":
                    Console.WriteLine("Exiting...");
                    Program.isGameRunning = false;
                    break;
            }
        }
   
}