using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BlackJack_Card_Game_ClassLibrary
{
    public class PlayerAndDealer
    {
        public int _currentCard = 0;

        public static void ColorShapes(Card TheCard)
        {
            if (TheCard._suit == " ♣ " || TheCard._suit == " ♠ ")
            {
                Thread.Sleep(300);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(TheCard._value);
                Console.Write(TheCard._suit + " ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("  ");
            }
            if (TheCard._suit == " ♥ " || TheCard._suit == " ♦ ")
            {
                Thread.Sleep(300);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(TheCard._value);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(TheCard._suit);
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("  ");
            }
        }

        public static void ItsATie(int DealerCardValueAdd1, int PlayerCardValueAdd1)
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("It's a tie!!");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Total amount in the Dealers hand: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(DealerCardValueAdd1);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Total amount in Your hand: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(PlayerCardValueAdd1);
            MainMenu.Resume();
        }

        public static void DealerWon(int DealerCardValueAdd1, int PlayerCardValueAdd1, int _initialMoney)
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("The Dealer Won");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Total amount in the Dealers hand: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(DealerCardValueAdd1);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Total amount in Your hand: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(PlayerCardValueAdd1);
            if (_initialMoney == 0)
            {
                int startOver = 1000;
                Console.WriteLine("You have ran all out of Money! \nThanks For Playing BlackJack \n\nStarting Over...");
                MainMenu.Resume();
                MainMenu.MenuOptions(startOver);
            }
            else
            {
                MainMenu.Resume();
            }
            
        }

        public static void PlayerWins(int DealerCardValueAdd2, int PlayerCardValueAdd2)
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("You Win!");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Total amount in the Dealers hand: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(DealerCardValueAdd2);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Total amount in Your hand: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(PlayerCardValueAdd2);
            MainMenu.Resume();
        }

        public static void CardCheck(int DealerCardValueAdd3, int PlayerCardValueAdd3, int _initialMoney, int bidAmountNumber)
        {
            if (DealerCardValueAdd3 == PlayerCardValueAdd3)
            {
                ItsATie(DealerCardValueAdd3, PlayerCardValueAdd3);
                _initialMoney += bidAmountNumber;
                MainMenu.MenuOptions(_initialMoney);
            }
            else if (PlayerCardValueAdd3 > DealerCardValueAdd3 && PlayerCardValueAdd3 < 22)
            {
                Console.WriteLine();
                PlayerWins(DealerCardValueAdd3, PlayerCardValueAdd3);
                _initialMoney += bidAmountNumber * 2;
                MainMenu.MenuOptions(_initialMoney);
            }
            else if (DealerCardValueAdd3 > PlayerCardValueAdd3 && DealerCardValueAdd3 < 22)
            {
                Console.WriteLine();
                DealerWon(DealerCardValueAdd3, PlayerCardValueAdd3, _initialMoney);
                MainMenu.MenuOptions(_initialMoney);
            }
        }

        public static void DisplayCards(List<Card> DealersCards1, List<Card> PlayersCards1, Card[] TheCards, char DisplayDealersExtraCard)
        {
            Console.WriteLine("Dealers visible Cards: ");
            Console.WriteLine();
            if(DisplayDealersExtraCard == 'Y')
            {
                ColorShapes(TheCards[2]);
                for (int index = 0; index < DealersCards1.Count; index++)
                {
                    ColorShapes(DealersCards1[index]);
                }
            }
            if(DisplayDealersExtraCard == 'N')
            {
                for (int index = 0; index < DealersCards1.Count; index++)
                {
                    ColorShapes(DealersCards1[index]);
                }
            }
            Console.WriteLine();
            Console.WriteLine("---------------------------");
            Console.WriteLine();
            Console.WriteLine("Your Cards: ");
            Console.WriteLine();
            for (int index = 0; index < PlayersCards1.Count; index++)
            {
                ColorShapes(PlayersCards1[index]);
            }
            Console.WriteLine();
        }
        
        public void PlayerAndDealerLogic(int _initialMoney, int bidAmountNumber)
        {
            Console.Clear();

            Deck MyDeck = new Deck();

            Card[] MyCards = new Card[52];

            MyDeck.CreateDeckOfCards(MyCards);

            MyDeck.CardShuffle(MyCards);

            Card CallDrawMethod = new Card("", "", 0);
            List<Card> PlayersCards = new List<Card>();
            List<Card> DealersCards = new List<Card>();

            List<Card> AlreadyDeductedAces = new List<Card>();
            
            int PlayerCardValueAdd = 0;
            int DealerCardValueAdd = 0;

            Console.WriteLine("Your Cards:");
            Console.WriteLine();

            CallDrawMethod.Draw(MyCards, ref _currentCard);
            ColorShapes(MyCards[_currentCard-1]);
            PlayersCards.Add(MyCards[_currentCard - 1]);

            PlayerCardValueAdd += MyCards[_currentCard - 1]._numberValue;
            
            CallDrawMethod.Draw(MyCards, ref _currentCard);
            ColorShapes(MyCards[_currentCard-1]);
            PlayersCards.Add(MyCards[_currentCard - 1]);

            PlayerCardValueAdd += MyCards[_currentCard - 1]._numberValue;

            if (MyCards[_currentCard - 1]._value == "A" && PlayerCardValueAdd > 21)
            {
                PlayerCardValueAdd -= 10;
                AlreadyDeductedAces.Add(MyCards[_currentCard - 1]);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Total amount in hand: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(PlayerCardValueAdd);
            MainMenu.Resume();

            Console.WriteLine();
            Console.WriteLine("You can see only one of the Dealers Cards:");
            Console.WriteLine();

            CallDrawMethod.Draw(MyCards, ref _currentCard);

            DealerCardValueAdd += MyCards[_currentCard - 1]._numberValue;
            
            CallDrawMethod.Draw(MyCards, ref _currentCard);
            ColorShapes(MyCards[_currentCard - 1]);
            DealersCards.Add(MyCards[_currentCard - 1]);

            DealerCardValueAdd += MyCards[_currentCard - 1]._numberValue;

            if (MyCards[_currentCard - 1]._value == "A" && DealerCardValueAdd > 21)
            {
                DealerCardValueAdd -= 10;
                AlreadyDeductedAces.Add(MyCards[_currentCard - 1]);
            }

            Console.WriteLine();
            MainMenu.Resume();

            _initialMoney -= bidAmountNumber;

            if (PlayerCardValueAdd == 21 && DealerCardValueAdd == 21)
            {
                Console.Clear();
                DisplayCards(DealersCards, PlayersCards, MyCards, 'Y');
                ItsATie(DealerCardValueAdd, PlayerCardValueAdd);
                _initialMoney += bidAmountNumber;
                MainMenu.MenuOptions(_initialMoney);
            }

            if (PlayerCardValueAdd == 21)
            {
                Console.Clear();
                DisplayCards(DealersCards, PlayersCards, MyCards, 'Y');
                PlayerWins(DealerCardValueAdd, PlayerCardValueAdd);
                _initialMoney += bidAmountNumber * 2;
                MainMenu.MenuOptions(_initialMoney);
            }

            if (DealerCardValueAdd == 21)
            {
                Console.Clear();
                DisplayCards(DealersCards, PlayersCards, MyCards, 'Y');
                DealerWon(DealerCardValueAdd, PlayerCardValueAdd, _initialMoney);
                MainMenu.MenuOptions(_initialMoney);
            }
            
            while(true)
            {
                
                if (PlayerCardValueAdd > 21)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("You Busted!");
                    Console.WriteLine();
                    DisplayCards(DealersCards, PlayersCards, MyCards, 'Y');
                    DealerWon(DealerCardValueAdd, PlayerCardValueAdd, _initialMoney);
                    MainMenu.MenuOptions(_initialMoney);

                }
                if (PlayerCardValueAdd == 21)
                {
                    Console.Clear();
                    DisplayCards(DealersCards, PlayersCards, MyCards, 'Y');
                    PlayerWins(DealerCardValueAdd, PlayerCardValueAdd);
                    _initialMoney += bidAmountNumber * 2;
                    MainMenu.MenuOptions(_initialMoney);
                }

                Console.Clear();
                DisplayCards(DealersCards, PlayersCards, MyCards, 'N');
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Your money: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("$");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(_initialMoney);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine();
                Console.Write("Total amount in your hand: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(PlayerCardValueAdd);

                Console.WriteLine("1. Hit? ");
                Console.WriteLine("2. Stay ");
                string HitYOrN = Console.ReadLine();
                int HitYOrNnumber;
                bool OneOrTwoChoice = int.TryParse((HitYOrN), out HitYOrNnumber);

                if(!OneOrTwoChoice)
                {
                    MainMenu.InvalidResponse();
                }
                else if(HitYOrNnumber > 2 || HitYOrNnumber < 1)
                {
                    MainMenu.InvalidResponse();
                }
                else if(HitYOrNnumber == 2)
                {
                    if(DealerCardValueAdd < 17)
                    {
                        while(true)
                        {
                            Console.Clear();
                            DisplayCards(DealersCards, PlayersCards, MyCards, 'N');
                            Console.WriteLine("----------------------------");
                            Console.WriteLine();
                            Console.WriteLine("Dealer chose to hit, Dealers New Card:");
                            Console.WriteLine();
                            CallDrawMethod.Draw(MyCards, ref _currentCard);
                            ColorShapes(MyCards[_currentCard-1]);
                            DealersCards.Add(MyCards[_currentCard - 1]);

                            DealerCardValueAdd += MyCards[_currentCard - 1]._numberValue;
                            
                            Console.WriteLine();

                            if (MyCards[_currentCard-1]._value == "A" && DealerCardValueAdd > 21)
                            {
                                DealerCardValueAdd -= 10;
                                AlreadyDeductedAces.Add(MyCards[_currentCard - 1]);
                            }
                            else if (MyCards[_currentCard - 1]._value != "A" && DealerCardValueAdd > 21)
                            {
                                for (int index = 0; index < DealersCards.Count; index++)
                                {
                                    if (MyCards[2]._value == "A" && DealerCardValueAdd > 21)
                                    {
                                        if (AlreadyDeductedAces.Contains(MyCards[2]))
                                        {
                                            // Do nothing, we just want the else end of this (the opposite of contains).
                                        }
                                        else
                                        {
                                            DealerCardValueAdd -= 10;
                                            AlreadyDeductedAces.Add(MyCards[2]);
                                            
                                        }
                                    }
                                    while (DealersCards[index]._value == "A" && DealerCardValueAdd > 21)
                                    {
                                        if (AlreadyDeductedAces.Contains(DealersCards[index]))
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            DealerCardValueAdd -= 10;
                                            AlreadyDeductedAces.Add(DealersCards[index]);
                                            break;
                                        }
                                    }
                                }
                            }

                            MainMenu.Resume();

                            if (DealerCardValueAdd > 21)
                            {
                                Console.Clear();
                                Console.WriteLine();
                                Console.WriteLine("The Dealer Busted!");
                                Console.WriteLine();
                                DisplayCards(DealersCards, PlayersCards, MyCards, 'Y');
                                PlayerWins(DealerCardValueAdd, PlayerCardValueAdd);
                                _initialMoney += bidAmountNumber * 2;
                                MainMenu.MenuOptions(_initialMoney);

                            }
                            else if (DealerCardValueAdd == 21)
                            {
                                Console.Clear();
                                DisplayCards(DealersCards, PlayersCards, MyCards, 'Y');
                                DealerWon(DealerCardValueAdd, PlayerCardValueAdd, _initialMoney);
                                MainMenu.MenuOptions(_initialMoney);
                            }
                            else if (DealerCardValueAdd >= 17)
                            {
                                Console.Clear();
                                Console.WriteLine();
                                Console.WriteLine("The Dealer chose to stay");
                                MainMenu.Resume();
                                Console.Clear();
                                DisplayCards(DealersCards, PlayersCards, MyCards, 'Y');
                                CardCheck(DealerCardValueAdd, PlayerCardValueAdd, _initialMoney, bidAmountNumber);
                            }
                            
                        }
                        
                    }
                    else if(DealerCardValueAdd >= 17)
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("The Dealer chose to stay");
                        MainMenu.Resume();
                        Console.Clear();
                        DisplayCards(DealersCards, PlayersCards, MyCards, 'Y');
                        CardCheck(DealerCardValueAdd, PlayerCardValueAdd, _initialMoney, bidAmountNumber);
                    }
                    
                }
                else if(HitYOrNnumber == 1)
                {
                    Console.Clear();
                    DisplayCards(DealersCards, PlayersCards, MyCards, 'N');
                    CallDrawMethod.Draw(MyCards, ref _currentCard);
                    Console.WriteLine();
                    Console.WriteLine("Your New Card: ");
                    Console.WriteLine();
                    ColorShapes(MyCards[_currentCard - 1]);
                    PlayersCards.Add(MyCards[_currentCard - 1]);

                    PlayerCardValueAdd += MyCards[_currentCard - 1]._numberValue;

                    if (MyCards[_currentCard - 1]._value == "A" && PlayerCardValueAdd > 21)
                    {
                        PlayerCardValueAdd -= 10;
                        AlreadyDeductedAces.Add(MyCards[_currentCard - 1]);
                    }
                    else if (MyCards[_currentCard - 1]._value != "A" && PlayerCardValueAdd > 21)
                    {
                        for (int index = 0; index < PlayersCards.Count; index++)
                        {
                            while (PlayersCards[index]._value == "A" && PlayerCardValueAdd > 21)
                            {
                                if (AlreadyDeductedAces.Contains(PlayersCards[index]))
                                {
                                    break;
                                }
                                else
                                {
                                    PlayerCardValueAdd -= 10;
                                    AlreadyDeductedAces.Add(PlayersCards[index]);
                                    break;
                                }
                            }
                        }
                    }

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Total amount in hand: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(PlayerCardValueAdd);
                    MainMenu.Resume();


                }
 
            }
               
        }
    }
}
