using System;
using System.Collections.Generic;
using System.Text;

namespace PokerConsole.Models
{
    public class Hand
    {
        public Hand()
        {
        }
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Name { get; set; }
        public List<Card> Cards { get; set; }


    }
}
