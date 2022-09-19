
namespace Blackjack
{
    class Program
    {
        internal static bool isGameRunning = true;
        
        static void Main(string[] args)
        {
            Player.SetInitialPlayerInformation(true);
            Console.Title = "BlackJack";

            while(isGameRunning)
            {
                UI.PrintLogo();
                UI.PrintPlayerMenuInfo();
                UI.PrintMenu();
                Game.HandleGame();

                Console.Clear();
            }
        }
    }
}