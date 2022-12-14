
namespace BlackjackGame;

public static class Game
{
    internal static void HandleGame()
        {
            Console.WriteLine("\nType in menu option number and press <Enter>");
            var selectedMenuOption = Console.ReadLine();

            switch (selectedMenuOption)
            {
                case "1":
                    Round.HandleNewRound();
                    break;
                case "2":
                    Console.WriteLine("Are you sure you want to reset your stat?\n1. Yes\n2. No");
                    var promptAnswer = Console.ReadLine();
                    if (promptAnswer == "1")
                    {
                        Player.ResetPlayerStats();
                    }
                    break;
                case "3":
                    Ui.PrintStats();
                    break;
                case "4":
                    Ui.PrintCredits();
                    break;
                case "5":
                    Console.WriteLine("Exiting...");
                    Program.IsGameRunning = false;
                    break;
            }
        }
   
}