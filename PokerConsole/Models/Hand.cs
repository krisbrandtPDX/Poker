using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PokerConsole.Models
{
    [DataContract(Name = "hand")]
    public class Hand
    {
        public Hand()
        {
        }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "timestamp")]
        public string Timestamp { get; set; }

        [DataMember(Name = "cards")]
        public List<Card> Cards { get; set; }
    }
}
