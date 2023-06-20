using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _230619WarmUp
{
    public class CardDeck
    {
        protected string[] cardNumber = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        protected string[] patterns = new string[] { "♣_", "♥_", "◆_", "♠_" };
        protected string[] cards = new string[52];
        protected int[] cardsLevel = new int[52];
        protected Dictionary<string, int> cardDeck = new Dictionary<string, int>();

        public virtual void Make_Deck()
        {
            for(int y = 0; y < 52; y ++)
            {
                cards[y] = patterns[y / 13] + cardNumber[y % 13];
                cardsLevel[y] = y;
                cardDeck.Add(cards[y], cardsLevel[y]);
            }
        }
    }
}
