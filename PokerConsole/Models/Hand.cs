using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace PokerConsole.Models
{
    [DataContract(Name = "hand")]
    public class Hand
    {
        public Hand()
        {
        }
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "playerId")]
        public int PlayerId { get; set; }
        [DataMember(Name = "timestamp")]
        public DateTime Timestamp { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "cards")]
        public List<Card> Cards { get; set; }


    }
}
