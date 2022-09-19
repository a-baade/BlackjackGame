
namespace BlackjackGame;

public static class Deck
{
    private static readonly string[] CardSuits = { "♥", "♦", "♣", "♠" };
    private static readonly string[] CardFaces = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };

    internal static readonly List<int> PlayerCardScores = new List<int>();
    internal static readonly List<int> DealerCardScores = new List<int>();

    internal static void HitCard(string pullerRole = "Player")
        {
            var randomGenerator = new Random();
            var cardSuit = CardSuits[randomGenerator.Next(CardSuits.Length)];

            var playingCardIndex = randomGenerator.Next(CardSuits.Length);
            var cardFace = CardFaces[playingCardIndex];
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
                PlayerCardScores.Add(cardScore);
                Console.ForegroundColor = ConsoleColor.Green;
                CalculateCardHit();
                totalCardScore = Round.PlayerTotalCardScore;
                cardScores = PlayerCardScores;
            }
            else
            {
                DealerCardScores.Add(cardScore);
                Console.ForegroundColor = ConsoleColor.Red;
                CalculateCardHit("Dealer");
                totalCardScore = Round.DealerTotalCardScore;
                cardScores = DealerCardScores;
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
                Round.PlayerTotalCardScore = CalculateCurrentTotalCardScore(PlayerCardScores);
            }
            else
            {
                Round.DealerTotalCardScore = CalculateCurrentTotalCardScore(DealerCardScores);
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