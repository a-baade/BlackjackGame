namespace Blackjack;

public class Deck
{
    static string[] cardSuits = { "♥", "♦", "♣", "♠" };
    static string[] cardFaces = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };

    internal static List<int> playerCardScores = new List<int>();
    internal static List<int> dealerCardScores = new List<int>();

    internal static void HitCard(string pullerRole = "Player")
        {
            var randomGenerator = new Random();
            var cardSuit = cardSuits[randomGenerator.Next(cardSuits.Length)];

            var playingCardIndex = randomGenerator.Next(cardSuits.Length);
            var cardFace = cardFaces[playingCardIndex];
            int cardScore;
            int totalCardScore;
            List<int> cardScores;

            if (playingCardIndex == 0)
            {
                cardScore = 11;
            }
            else if(playingCardIndex < 9)
            {
                cardScore = playingCardIndex + 1;
            }
            else
            {
                cardScore = 10;
            }

            if(pullerRole == "Player")
            {
                playerCardScores.Add(cardScore);
                Console.ForegroundColor = ConsoleColor.Green;
                CalculateCardHit();
                totalCardScore = Round.playerTotalCardScore;
                cardScores = playerCardScores;
            }
            else
            {
                dealerCardScores.Add(cardScore);
                Console.ForegroundColor = ConsoleColor.Red;
                CalculateCardHit("Dealer");
                totalCardScore = Round.dealerTotalCardScore;
                cardScores = dealerCardScores;
            }

            Console.WriteLine($"\n{pullerRole} is drawing a card..");
            Console.Write("Current card scores: |");
            foreach(var card in cardScores)
            {
                Console.Write($" {card} |");
            }

            Console.WriteLine($"\n{pullerRole} drew - | {cardSuit} {cardFace} {cardSuit} | ({cardScore}).");
            Console.WriteLine($"[{pullerRole}] -> Current hand score: {totalCardScore}\n");
        }

        private static void CalculateCardHit(string pullerRole = "Player")
        {
            if (pullerRole == "Player")
            {
                Round.playerTotalCardScore = CalculateCurrentTotalCardScore(playerCardScores);
            }
            else
            {
                Round.dealerTotalCardScore = CalculateCurrentTotalCardScore(dealerCardScores);
            }
        }
        private static int CalculateCurrentTotalCardScore(List<int> cardScores)
        {
            var totalCardScore = cardScores.Sum();

            if(totalCardScore > 21)
            {
                var aceCard = cardScores.FirstOrDefault(cs => cs == 11);
                cardScores.Remove(aceCard);
                cardScores.Add(1);
                totalCardScore = cardScores.Sum();
            }

            return totalCardScore;
        }
}