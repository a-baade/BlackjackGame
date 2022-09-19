
namespace BlackjackGame;

public static class Round
{
    internal static int PlayerTotalCardScore;
    internal static int DealerTotalCardScore;
    
    internal static void HandleNewRound()
        {
            PrepareNewRound();
            Bet.SetBetAmount();
            PrintNewGameMessage();

            if (!Bet.IsBetValid())
            {
                PrintInvalidBetMessage();
            }

            Deck.HitCard("Dealer");

            bool canHit = true;

            while(canHit)
            {
                Deck.HitCard();
                canHit = CanHitAgain();
            }

            while(DealerTotalCardScore < 17)
            {
                Deck.HitCard("Dealer");
            }

            PrintTotalScore();
            PrintTotalScore("Dealer");
            CalculateRoundResult();
        }

        private static bool CanHitAgain()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            if(PlayerTotalCardScore < 21)
            {
                Console.WriteLine("Do you want to hit again?\n1. Yes 2. No");
                var hitAgain = Console.ReadLine();

                if(hitAgain == "1")
                {
                    return true;
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            return false;
        }

        private static void PrintInvalidBetMessage()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\nYou have insufficient funds..");
            Console.WriteLine("Press any key to quit..");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }

        private static void CalculateRoundResult()
        {
            if (PlayerTotalCardScore > 21 || PlayerTotalCardScore <= DealerTotalCardScore)
            {
                Player.CurrentWinningStreak = 0;
                Player.PlayerMoney -= Bet.BettingAmount;
                PrintRoundLost();
            }
            else
            {
                double wonBonusAmount = Bet.BettingAmount * 0.05 * Player.CurrentWinningStreak;
                double wonAmount = Bet.BettingAmount + wonBonusAmount;

                Player.CurrentWinningStreak++;

                if (Player.BestWinningStreak < Player.CurrentWinningStreak)
                {
                    Player.BestWinningStreak = Player.CurrentWinningStreak;
                }

                Player.PlayerMoney += wonAmount;
                PrintRoundWon(wonAmount);
            }
        }

        private static void PrintRoundWon(double wonAmount)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Dealer busted!!\nYou win {wonAmount}$!!\nYour current winnings: {Player.PlayerMoney}$\n\nPress any key to continue..");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }

        private static void PrintRoundLost()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"House wins! {Bet.BettingAmount}$..\nYour current winnings: {Player.PlayerMoney}$\n\nPress any key to continue..");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }
        
        private static void PrintTotalScore(string pullerRole = "Player")
        {
            if (pullerRole == "Player")
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"{pullerRole} total card score: {PlayerTotalCardScore}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"{pullerRole} total card score: {DealerTotalCardScore}");
            }
            
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void PrepareNewRound()
        {
            Deck.PlayerCardScores.Clear();
            Deck.DealerCardScores.Clear();
            PlayerTotalCardScore = 0;
            DealerTotalCardScore = 0;
            Bet.BettingAmount = 0;
        }

        private static void PrintNewGameMessage()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Shuffling the deck..");
            Console.WriteLine("Done shuffling the deck.");
            Console.WriteLine("Serving the cards");
            Console.ForegroundColor = ConsoleColor.White;
        }
}