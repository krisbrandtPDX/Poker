using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;

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

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "cards")]
        public List<Card> Cards { get; set; }

        [DataMember(Name = "timestamp")]
        private string JsonTimestamp { get; set; }

        [IgnoreDataMember]
        public DateTime Timestamp
        {
            get
            {
                return DateTime.ParseExact(JsonTimestamp, "yyyy-MM-ddTHH:mm:ss.fffffffZ", CultureInfo.InvariantCulture);
            }
        }

    }
}
