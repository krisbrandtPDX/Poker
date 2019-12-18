using System;
using System.Collections.Generic;
using System.Text;

namespace PokerConsole.Models
{
    public class Card
    {
        public Card()
        {
        }
        public int CardId { get; set; }
        public int HandId { get; set; }
        public int Rank { get; set; }
        public int Suit { get; set; }
        public int RankAscii { get; set; }
        public int SuitAscii { get; set; }
        public string Name { get; set; }
    }
}
