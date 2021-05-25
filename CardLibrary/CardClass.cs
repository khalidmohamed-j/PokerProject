using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary
{
    public class CardClub : SuperCard
    {
        private Suit _CardSuit = Suit.Club;

        public override Suit CardSuit
        {
            get { return _CardSuit; }

        }
        public CardClub(Rank c)
        {
            CardRank = c;
        }

        public override void Display()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(CardRank + " of " + _CardSuit + "s ♣");
            Console.ResetColor();
        }
    }

    public class CardDiamond : SuperCard
    {

        private Suit _CardSuit = Suit.Diamond;

        public override Suit CardSuit
        {
            get { return _CardSuit; }

        }


        public CardDiamond(Rank d)
        {
            CardRank = d;
        }

        public override void Display()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(CardRank + " of " + _CardSuit + "s ♦");
            Console.ResetColor();
        }
    }

    class CardHeart : SuperCard
    {
        private Suit _CardSuit = Suit.Heart;

        public override Suit CardSuit
        {
            get { return _CardSuit; }

        }


        public CardHeart(Rank h)
        {
            CardRank = h;
        }

        public override void Display()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(CardRank + " of " + _CardSuit + "s ♥");
            Console.ResetColor();
        }
    }

    class CardSpade : SuperCard
    {
        private Suit _CardSuit = Suit.Spade;

        public override Suit CardSuit
        {
            get { return _CardSuit; }

        }


        public CardSpade(Rank s)
        {
            CardRank = s;
        }
        public override void Display()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(CardRank + " of " + _CardSuit + "s ♠");
            Console.ResetColor();
        }
    }
}

