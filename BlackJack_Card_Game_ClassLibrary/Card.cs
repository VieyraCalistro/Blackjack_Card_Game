using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BlackJack_Card_Game_ClassLibrary
{
    public class Card
    {
        public string _suit;
        public string _value;
        public int _numberValue;

        public Card(string asuit, string avalue, int anumberValue)
        {
            _suit = asuit;
            _value = avalue;
            _numberValue = anumberValue;
        }

        public Card Draw(Card[] TheCards, ref int CurrentCard)
        {

            if (CurrentCard < TheCards.Length)
            {
                return TheCards[CurrentCard++];
            }
            else
            {
                return null;
            }
        }


    }
}
