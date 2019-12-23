using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace PokerAPI.Models
{
    public class Hand
    {
        public Hand()
        {
            Cards = new List<Card>();
        }
        public List<Card> Cards { get; set; }

        [IgnoreDataMember]
        public int Id { get; set; }
        [IgnoreDataMember]
        public int PlayerId { get; set; }
        [IgnoreDataMember]
        public DateTime Timestamp { get; set; }

        public string Name => DetermineHand();
      
        private bool IsRoyalFlush => IsStraight && IsFlush && Cards.Last().Rank == 13;
        private bool IsStraightFlush => IsStraight && IsFlush;
        private bool IsQuads => Cards[0].Rank == Cards[3].Rank || Cards[1].Rank == Cards[4].Rank;
        private bool IsFullHouse => DistinctRanks == 2 && !IsQuads;
        private bool IsFlush => DistinctSuits == 1;
        private bool IsStraight => DistinctRanks == 5 && Cards[0].Rank == Cards[4].Rank - 4;
        private bool IsStraightAceLow => DistinctRanks == 5 && Cards[4].Rank == 13 && Cards[3].Rank == 3; //Card #4 must be a 5
        private bool IsTrips => (Cards[0].Rank == Cards[2].Rank || Cards[1].Rank == Cards[3].Rank || Cards[2].Rank == Cards[4].Rank) && !IsFullHouse;
        private bool IsTwoPair => DistinctRanks == 3 && !IsTrips;
        private bool IsPair => DistinctRanks == 4;
        private int DistinctRanks => Cards.Select(c => c.Rank).Distinct().Count();
        private int DistinctSuits => Cards.Select(c => c.Suit).Distinct().Count();

        private string DetermineHand()
        {
            if (Cards.Count() == 5)
            {
                if (IsRoyalFlush) { return "Royal Flush"; }
                if (IsStraightFlush) { return "Straight Flush"; }
                if (IsQuads) { return "Quads"; }
                if (IsFullHouse) { return "Full House"; }
                if (IsFlush) { return "Flush"; }
                if (IsStraight) { return "Straight"; }
                if (IsStraightAceLow) { return "Straight, Ace Low"; }
                if (IsTrips) { return "Trips"; }
                if (IsTwoPair) { return "Two Pair"; }
                if (IsPair) { return "Pair"; }
            }
            return "High Card";
        }
    }
}
