using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack_Card_Game_ClassLibrary
{
    public class MainMenu
    {
        public static void InvalidResponse()
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Invalid response");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public static void Resume()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press any key to continue");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }

        public static void MenuOptions(int _initialMoney)
        {
            Deck MyDeck = new Deck();

            Card[] MyCards = new Card[52];

            MyDeck.CreateDeckOfCards(MyCards);

            PlayerAndDealer game = new PlayerAndDealer();

            int bidAmountNumber;

            while (true)
            {
                Console.Clear();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Your money: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("$");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(_initialMoney);
                Console.WriteLine();
                Console.WriteLine("1. Play Game");
                Console.WriteLine("2. Shuffle Cards");
                Console.WriteLine("3. Exit");
                string response = Console.ReadLine();
                int responseConversion;
                bool checkingForMenuNumber = int.TryParse((response), out responseConversion);

                if (!checkingForMenuNumber)
                {
                    InvalidResponse();
                }
                else if (responseConversion < 1 || responseConversion > 3)
                {
                    InvalidResponse();
                }
                else if(responseConversion == 3)
                {
                    Environment.Exit(0);
                }
                else if (responseConversion == 2)
                {
                    Console.Clear();
                    MyDeck.CardShuffle(MyCards);
                    MyDeck.Print(MyCards);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Resume();
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (responseConversion == 1)
                {
                    while (true)
                    {

                        Console.Clear();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Your money: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("$");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(_initialMoney);
                        Console.WriteLine();
                        Console.WriteLine("How much would you like to bid?");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Note: $100 minimum bids with $100 increments Only");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine();
                        Console.Write("$");
                        Console.ForegroundColor = ConsoleColor.White;
                        string bidAmount = Console.ReadLine();
                        bool checkingForNumber = int.TryParse((bidAmount), out bidAmountNumber);

                        if (!checkingForNumber)
                        {
                            InvalidResponse();
                        }
                        else if (bidAmountNumber > _initialMoney || bidAmountNumber < 100)
                        {
                            InvalidResponse();
                        }
                        else if (bidAmountNumber % 100 != 0)
                        {
                            InvalidResponse();
                        }
                        else if(bidAmountNumber % 100 == 0)
                        {
                            break;
                        }
                    }

                    game.PlayerAndDealerLogic(_initialMoney, bidAmountNumber);
                }
            }

        }
    }
}
