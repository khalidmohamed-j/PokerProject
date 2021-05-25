using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardLibrary;

namespace PokerProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();


            CardSet myDeck = new CardSet();

            int howManyCards = 3;
            int balance = 10;
             

            while (balance != 0)
            {

                myDeck.ResetUsage();

                SuperCard[] computerHand = myDeck.Getcards(howManyCards);
                SuperCard[] playerHand = myDeck.Getcards(howManyCards);

                Array.Sort(computerHand);
                Array.Sort(playerHand);

                DisplayHands(computerHand, playerHand);

                PlayerDrawsOne(playerHand, myDeck);
                ComputerDrawsOne(computerHand, myDeck);

                DisplayHands(computerHand, playerHand);

                Flush(computerHand);
                Flush(playerHand);

                bool won = CompareHands(computerHand, playerHand);
                if (won)
                {
                    balance += 1;
                    Console.WriteLine("You won. Your balance is {0} ", balance);
                    Console.WriteLine("Type Enter to play another hand.");
                }
                else
                {
                    balance -= 1;
                    Console.WriteLine("You lost. Your balance is {0} ", balance);
                    Console.WriteLine("Type Enter to play another hand.");
                }
                Console.ReadLine();
            }
            Console.ReadLine();
        }

        private static void ComputerDrawsOne(SuperCard[] computerHand, CardSet myDeck)
        {
            if (Flush(computerHand))
            {
                Flush(computerHand);
            }

            if (!Flush(computerHand))
            {
                int lowestIndex = 0;
                int lowestValue = (int)computerHand[0].CardRank;

                for (int i = 1; i < computerHand.Length; i++)
                {
                    int currentValue = (int)computerHand[i].CardRank;

                    if (currentValue < lowestValue)
                    {
                        lowestValue = currentValue;
                        lowestIndex = i;
                    }
                }

                if (lowestValue <= (int)Rank.Seven)
                {
                    computerHand[lowestIndex] = myDeck.GetOneCard();
                }
            }
            
        }

        private static void PlayerDrawsOne(SuperCard[] playerHand, CardSet myDeck)
        {
            bool validInput;
            int whichCardToReplace;

            Console.WriteLine("Which card do you want to replace ?");
            Console.WriteLine("Enter 0 if you don't want to replace any card.");

            string input = Console.ReadLine();
            validInput = int.TryParse(input, out whichCardToReplace);

            if (whichCardToReplace != 0)
            {
                playerHand[whichCardToReplace - 1] = myDeck.GetOneCard();
            }
        }
        
        private static bool CompareHands(SuperCard[] computerHand, SuperCard[] playerHand)
        {
              
            if (Flush(playerHand) && Flush(computerHand))
            {

                Console.WriteLine("It's a double flush, computer won.");

                return false; 
            }
            if (Flush(computerHand))
            {

                Console.WriteLine("It's a flush, computer won.");

                return false;
            }
            if (Flush(playerHand))
            {

                Console.WriteLine("It's a flush, player won.");

                return true; 
            }

            bool compareValue = false;
            int computerValue = 0;
            int playerValue = 0;

            for (int i = 0; i < computerHand.Length; i++)
            {
                computerValue += (int)computerHand[i].CardRank;
                playerValue += (int)playerHand[i].CardRank;
            }

            if (playerValue > computerValue)
            {
                compareValue = true;
            }

            return compareValue;

        }

        private static void DisplayHands(SuperCard[] computerHand, SuperCard[] playerHand)
        {
            //Console.Clear();
            Console.WriteLine("Computer's Hand");


            for (int i = 0; i < computerHand.Length; i++)
            {

                computerHand[i].Display();
            }

            Console.WriteLine();
            Console.WriteLine("Player's Hand");

            for (int i = 0; i < playerHand.Length; i++)
            {
                playerHand[i].Display();
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
        }

        private static bool Flush(SuperCard[] hand)
        {
            for (int i = 0; i < hand.Length; i++)
            {
                if (hand[i].CardSuit != hand[hand.Length - 1].CardSuit)
                {
                    return false;
                }
                
            }
            return true;
        }

    }
}