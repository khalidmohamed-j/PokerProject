using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary
{
    public enum Suit
    { 
        
        Club = 1,
        Diamond,
        Heart,
        Spade
    }

    public enum Rank
    {
        
        Deuce = 2,
        Three = 3,
        Four =4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14
    }

    public abstract class SuperCard: IComparable<SuperCard>, IEquatable<SuperCard>
    {
        public Rank CardRank { get; set; } 
        public abstract Suit CardSuit { get; }

        public bool Inplay { get; set; }

        public int CompareTo(SuperCard other)
        {         
            if (other.CardSuit < this.CardSuit)
            {             
                return 1;
            }           
            else if (other.CardSuit > this.CardSuit)
            {                
                return -1;
            }
            else if (other.CardSuit == this.CardSuit)
            {
                return CardRank.CompareTo(other.CardRank);
            }
            return 0;
        }

        public abstract void Display();        

        public bool Equals(SuperCard otherCard)
        {
            if (this.CardSuit == otherCard.CardSuit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
