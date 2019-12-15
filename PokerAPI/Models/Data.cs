using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokerAPI.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Hand
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class Card
    {
        public int Id { get; set; }
        public int HandId { get; set; }
    }
}
