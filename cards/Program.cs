using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace cards
{
    class CardShuffle
    {
        static void Main(string[] args)
        {
            List<Card> cards = new List<Card>();
            Console.WriteLine("Enter card (format: 'Face Suit'):");

          
         
            //TO DO READ FROM THE CONSOLE FACE OF THE CARD AND SUIT (face could be an integer or string and the suit is enum )
            Console.WriteLine("Initial Deck:");
            PrintCards(cards);

            ShuffleCards(cards);
            Console.WriteLine("Shuffled Deck:");
                PrintCards(cards);
        }

        static Random rand = new Random();
        static void PerformSingleExchange(List<Card> cards)

        {

        

            int randomIndex = rand.Next(1, cards.Count);

            Card firstCard = cards[0];

            Card randomCard = cards[randomIndex];

            cards[0] = randomCard;

            cards[randomIndex] = firstCard;

        }
        static void ShuffleCards(List<Card> cards)

        {

            for (int i = 1; i <= cards.Count; i++)

            {

                PerformSingleExchange(cards);

            }

        }
        static void PrintCards(List<Card> cards)
        {
            foreach (Card card in cards)
            {
                Console.WriteLine(card);
            }
            Console.WriteLine();
        }



    }
}

