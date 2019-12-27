using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace PokerConsole.Models
{
    [DataContract(Name = "card")]
    public class Card
    {
        public Card()
        {
        }
        [DataMember(Name = "cardId")]
        public int CardId { get; set; }

        [DataMember(Name = "rank")]
        public int Rank { get; set; }
        [DataMember(Name = "suit")]
        public int Suit { get; set; }
        [DataMember(Name = "shortName")]
        public string ShortName { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
