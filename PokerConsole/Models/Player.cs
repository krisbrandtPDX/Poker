using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace PokerConsole.Models
{
    [DataContract(Name = "player")]
    public class Player
    {
        public Player()
        {
        }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "hands")]
        public List<Hand> Hands { get; set; }
    }
}
