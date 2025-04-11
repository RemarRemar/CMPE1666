using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEnums
{
    internal class Program
    {
        public enum Suit { Spade = 1, Heart, Diamond, Club };

        public enum Face { Jack = 11, Queen, King };

        private struct Cards
        {
            public Suit CardSuit;           // pulled from the enum
            public int Value;
            public bool Played;

            // The Contructor
            public Cards(Suit cardsuit, int value, bool played)  // lower case in parameter
            {
                CardSuit = cardsuit;            // Setting up the Contructor
                Value = value;
                Played = played;
            }
        }

        //Global Variables
        static Random random = new Random();

        static void Main(string[] args)
        {
            Cards[] deck = new Cards[52];        // Max number of Cards
            string WhatIsIt;
            Suit WhatSuit;
            int WhatNum;
            deck = FillDeck(deck);
            WhatNum = (int)deck[0].CardSuit;
            //WhatIsIt = (string)deck[0].CardSuit;
            WhatSuit = deck[0].CardSuit;
            DisplayDeck(deck);
            Console.ReadKey();
            Console.Clear();
            deck = ShuffleDeck(deck);
            DisplayDeck(deck);
            Console.ReadKey();
        }

        static Cards[] FillDeck(Cards[] deck)
        {
            Cards[] FullDeck = new Cards[deck.Length];
            string[] sSuits = new string[4] { "Spade", "Heart", "Diamond", "Club" };
            int index = 0;
            Suit type;

            for (int i = 1; i < 5; i++)
            {
                for (int j = 1; j < 14; j++)
                {
                    Enum.TryParse(sSuits[i - 1], out type);
                    FullDeck[index].CardSuit = type;
                    FullDeck[index].Value = j;
                    FullDeck[index].Played = false;
                    index++;
                }
            }
            return FullDeck;
        }

        static Cards[] ShuffleDeck(Cards[] deck)
        {
            Cards[] ShuffledDeck = new Cards[deck.Length];
            int x = 0;

            for (int index = 0; index < 52; index++)
            {
                do
                {
                    x = random.Next(0, 52);
                }
                while (ShuffledDeck[x].Value != 0);
                ShuffledDeck[x] = deck[index];
            }
            return ShuffledDeck;
        }

        static void DisplayDeck(Cards[] deck)
        {
            for (int i = 0; i < 52; i++)
            {
                if (i % 13 == 0)
                    Console.WriteLine();

                if (deck[i].Value > 10)
                    Console.WriteLine($"{Enum.GetName(typeof(Face), deck[i].Value)} {deck[i].CardSuit}s {deck[i].Played}");
                else if (deck[i].Value == 1)
                    Console.WriteLine($"Ace {deck[i].CardSuit}s {deck[i].Played}");
                else
                    Console.WriteLine($"{deck[i].Value} {deck[i].CardSuit}s {deck[i].Played}");
            }
            return;
        }
    }
}
