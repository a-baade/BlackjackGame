
namespace BlackjackGame
{
    internal static class Program
    {
        internal static bool IsGameRunning = true;

        private static void Main(string[] args)
        {
            Player.SetInitialPlayerInformation(true);
            Console.Title = "BlackJack";

            while(IsGameRunning)
            {
                Ui.PrintLogo();
                Ui.PrintPlayerMenuInfo();
                Ui.PrintMenu();
                Game.HandleGame();

                Console.Clear();
            }
        }
    }
}