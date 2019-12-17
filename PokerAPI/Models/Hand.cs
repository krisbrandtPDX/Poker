using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerAPI.Models
{
    public class Hand
    {
        public Hand()
        {
            Cards = new List<Card>();
        }
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public DateTime Timestamp { get; set; }
        public List<Card> Cards { get; set; }

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
            string name = "High Card";
            if (Cards.Count() == 5)
            {
                if (IsRoyalFlush) { name = "Royal Flush"; }
                if (IsStraightFlush) { name = "Straight Flush"; }
                if (IsQuads) { name = "Quads"; }
                if (IsFullHouse) { name = "Full House"; }
                if (IsFlush) { name = "Flush"; }
                if (IsStraight) { name = "Straight"; }
                if (IsStraightAceLow) { name = "Straight, Ace Low"; }
                if (IsTrips) { name = "Trips"; }
                if (IsTwoPair) { name = "Two Pair"; }
                if (IsPair) { name = "Pair"; }
            }
            return name;
        }
    }
}
