﻿using System.Collections.Generic;

namespace PokerAPI.Models
{
    public class Player
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Hand> Hands { get; set; }
    }
}
