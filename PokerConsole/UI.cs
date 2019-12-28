using PokerConsole.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokerConsole
{
    public static class UI
    {
        public static string Prompt(string msg, string defaultReturn = "")
        {
            string userInput = "";
            Console.WriteLine(msg);
            userInput = Console.ReadLine().Trim();
            if (userInput == "")
            {
                Console.WriteLine(defaultReturn);
                userInput = defaultReturn;
            }
            return userInput;
        }

        public static void Notify(string msg)
        {
            Console.WriteLine(msg);
        }

        public static void DisplayHand(Hand hand)
        {
            string display = hand.Timestamp + "  ||  ";
            foreach (Card c in hand.Cards)
            {
                display += c.ShortName + " ";
            }
            display += "  =>  " + hand.Name;
            Console.WriteLine(display);
        }
    }
}
