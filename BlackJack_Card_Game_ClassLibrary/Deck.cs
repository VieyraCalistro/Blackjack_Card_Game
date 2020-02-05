using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BlackJack_Card_Game_ClassLibrary
{
    
    public class Deck
    {
        public Card[] CreateDeckOfCards(Card[] YourCards)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string[] CardValue = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
            string[] CardSuit = new string[4];
            CardSuit[0] = " ♥ ";
            CardSuit[1] = " ♣ ";
            CardSuit[2] = " ♠ ";
            CardSuit[3] = " ♦ ";
            int[] CardNumberValue = { 11, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10 };
            
            for (int i = 0; i < YourCards.Length; i++)
            {
                YourCards[i] = new Card(CardSuit[i / 13], CardValue[i % 13], CardNumberValue[i % 13]);
            }
            return YourCards;
        }

        public Card[] CardShuffle(Card[] YourCards)
        {
            Card temp;
            Random r = new Random();

            for (int i = 0; i < YourCards.Length; i++)
            {
                int rand = r.Next(52);
                temp = YourCards[i];
                YourCards[i] = YourCards[rand];
                YourCards[rand] = temp;
            }
            return YourCards;
        }

        public void Print(Card[] YourCards)
        {

            foreach (Card value in YourCards)
            {
                if (value != null)
                {
                    Thread.Sleep(70);

                    if (value._suit == " ♣ " || value._suit == " ♠ ")
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(value._value);
                        Console.Write(value._suit + " ");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("  ");
                    }
                    if (value._suit == " ♥ " || value._suit == " ♦ ")
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(value._value);
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(value._suit);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write("  ");
                    }
                }
            }
        }
    }
}
