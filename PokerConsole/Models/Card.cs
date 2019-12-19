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
        [DataMember(Name = "handId")]
        public int HandId { get; set; }
        [DataMember(Name = "rank")]
        public int Rank { get; set; }
        [DataMember(Name = "suit")]
        public int Suit { get; set; }
        [DataMember(Name = "rankAscii")]
        public int RankAscii { get; set; }
        [DataMember(Name = "suitAscii")]
        public int SuitAscii { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
