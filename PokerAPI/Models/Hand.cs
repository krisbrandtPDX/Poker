using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerAPI.Models
{
    public class Hand
    {
        public Hand()
        {
            GetCards();
            SortCards();
            DetermineHand();
            Timestamp = DateTime.Now;
        }
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public DateTime Timestamp { get; set; }
        public List<Card> Cards { get; set; }
        private bool IsRoyalFlush => IsStraight && IsFlush && Cards.Last().Rank == 13;
        private bool IsStraightFlush => IsStraight && IsFlush;
        private bool IsQuads => FindMatchingCards(4);
        private bool IsFullHouse => DistinctRanks == 2 && !IsQuads;
        private bool IsFlush => DistinctSuits == 1;
        private bool IsStraight => DistinctRanks == 5 && Cards.First().Rank == Cards.Last().Rank - 4;
        private bool IsStraightAceLow => DistinctRanks == 5 && Cards.Last().Rank == 13 && Cards.SkipLast(1).Last().Rank == 3; //Card #4 must be a 5
        private bool IsTrips => FindMatchingCards(3);
        private bool IsTwoPair => DistinctRanks == 3 && !IsTrips;
        private bool IsPair => DistinctRanks == 4;
        private int DistinctRanks => Cards.Select(c => c.Rank).Distinct().Count();
        private int DistinctSuits => Cards.Select(c => c.Suit).Distinct().Count();
       
        private void GetCards()
        {
            int i = 0;
            Random rnd = new Random();
            Cards = new List<Card>();
            while (i < 5)
            {
                Card card = new Card() { Id = rnd.Next(0, 51) };
                if (Cards.Find(c => c.Id == card.Id) == null)
                {
                    Cards.Add(card);
                    i++;
                }
            }
        }

        private void SortCards()
        {
            Cards = Cards.OrderBy(c => c.Rank).ThenBy(c => c.Suit).ToList();
        }

        private void DetermineHand()
        {
            Name = "High Card";
            if (IsRoyalFlush) { Name = "Royal Flush"; }
            if (IsStraightFlush) { Name = "Straight Flush"; }
            if (IsQuads) { Name = "Quads"; }
            if (IsFullHouse) { Name = "Full House"; }
            if (IsFlush) { Name = "Flush"; }
            if (IsStraight) { Name = "Straight"; }
            if (IsStraightAceLow) { Name = "Straight, Ace Low"; }
            if (IsTrips) { Name = "Trips"; }
            if (IsTwoPair) { Name = "Two Pair"; }
            if (IsPair) { Name = "Pair"; }
        }
        private bool FindMatchingCards(int n)
        {
            bool found = false;
            int i = 0, targetIndex = 5 - n;
            while (!found && i <= targetIndex)
            {
                found = Instances(Cards[i++].Rank) == n;
            }
            return found;
        }

        private int Instances(int rank)
        {
            return Cards.Where(c => c.Rank == rank).Count();
        }

    }
}
