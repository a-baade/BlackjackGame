namespace Blackjack;

public class Round
{
    internal static int playerTotalCardScore = 0;
    internal static int dealerTotalCardScore = 0;
    
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

            while(dealerTotalCardScore < 17)
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
            if(playerTotalCardScore < 21)
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
            if (playerTotalCardScore > 21 || playerTotalCardScore <= dealerTotalCardScore)
            {
                Player.currentWinningStreak = 0;
                Player.playerMoney -= Bet.bettingAmount;
                PrintRoundLost();
            }
            else
            {
                double wonBonusAmount = Bet.bettingAmount * 0.05 * Player.currentWinningStreak;
                double wonAmount = Bet.bettingAmount + wonBonusAmount;

                Player.currentWinningStreak++;

                if (Player.bestWinningStreak < Player.currentWinningStreak)
                {
                    Player.bestWinningStreak = Player.currentWinningStreak;
                }

                Player.playerMoney += wonAmount;
                PrintRoundWon(wonAmount);
            }
        }

        private static void PrintRoundWon(double wonAmount)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Dealer busted!!\nYou win {wonAmount}$!!\nYour current winnings: {Player.playerMoney}$\n\nPress any key to continue..");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }

        private static void PrintRoundLost()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"House wins! {Bet.bettingAmount}$..\nYour current winnings: {Player.playerMoney}$\n\nPress any key to continue..");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }
        
        private static void PrintTotalScore(string pullerRole = "Player")
        {
            if (pullerRole == "Player")
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"{pullerRole} total card score: {playerTotalCardScore}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"{pullerRole} total card score: {dealerTotalCardScore}");
            }
            
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void PrepareNewRound()
        {
            Deck.playerCardScores.Clear();
            Deck.dealerCardScores.Clear();
            playerTotalCardScore = 0;
            dealerTotalCardScore = 0;
            Bet.bettingAmount = 0;
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