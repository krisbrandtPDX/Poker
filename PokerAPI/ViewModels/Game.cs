using PokerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokerAPI.ViewModels
{
    public class Game
    {
        public IEnumerable<Player> Players { get; set; }
    }
}
