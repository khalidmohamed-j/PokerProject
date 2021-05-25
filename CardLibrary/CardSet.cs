using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardLibrary;

namespace CardLibrary
{
    public class CardSet
    {
        public SuperCard[] cardArray;

        Random rnd = new Random();


        public CardSet()
        {
            cardArray = new SuperCard[52];

            for (int i = 0; i < Enum.GetNames(typeof(Rank)).Length; i++)
            {
                cardArray[i] = new CardClub((Rank)i + 2);
                cardArray[i + Enum.GetNames(typeof(Rank)).Length] = new CardDiamond((Rank)i + 2);
                cardArray[i + Enum.GetNames(typeof(Rank)).Length * 2] = new CardHeart((Rank)i + 2);
                cardArray[i + Enum.GetNames(typeof(Rank)).Length * 3] = new CardSpade((Rank)i + 2);

            }
        }

        public SuperCard[] Getcards(int howManyCards)
        {
            SuperCard[] cardArrayDraw = new SuperCard[howManyCards];
            for (int i = 0; i < howManyCards; i++)
            {
                SuperCard card = cardArray[rnd.Next(52)];
                if (!card.Inplay)
                {
                    card.Inplay = true;
                    cardArrayDraw[i] = card;
                }
                else
                {
                    i--;
                }
            }
            return cardArrayDraw;
        }
        public void ResetUsage()
        {
            foreach (SuperCard card in cardArray)
            {
                card.Inplay = false;
            }
        }

        public SuperCard GetOneCard()
        {
            SuperCard OneCard;
            bool FoundCard = false;
            do
            {
                OneCard = cardArray[rnd.Next(52)];
                if (!OneCard.Inplay)
                {
                    OneCard.Inplay = true;
                    FoundCard = true;
                }

            } while (!FoundCard);


            return OneCard;
        }
    }
}     

