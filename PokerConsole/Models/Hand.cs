using System;
using System.Collections.Generic;
using System.Text;

namespace PokerConsole.Models
{
    class Hand
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
