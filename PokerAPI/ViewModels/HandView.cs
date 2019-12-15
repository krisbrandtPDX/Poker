using PokerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerAPI.ViewModels
{
    public class HandView
    {
        private readonly PokerAPIContext _context;
        public HandView(int handId)
        {
            Cards = _context.Cards.Where(c => c.HandId == handId);
        }
        public string Name { get; set; }
        public IEnumerable<Card> Cards { get; set; }
        //private bool IsRoyalFlush => IsStraight && IsFlush && Cards.Last().Rank == 13;
        //private bool IsStraightFlush => IsStraight && IsFlush;
        //private bool IsQuads => FindMatchingCards(4);
        //private bool IsFullHouse => DistinctRanks == 2 && !IsQuads;
        //private bool IsFlush => DistinctSuits == 1;
        //private bool IsStraight => DistinctRanks == 5 && Cards.First().Rank == Cards.Last().Rank - 4;
        //private bool IsStraightAceLow => DistinctRanks == 5 && Cards.Last().Rank == 13 && Cards.SkipLast(1).Last().Rank == 3; //Card #4 must be a 5
        //private bool IsTrips => FindMatchingCards(3);
        //private bool IsTwoPair => DistinctRanks == 3 && !IsTrips;
        //private bool IsPair => DistinctRanks == 4;
        //private int DistinctRanks => Cards.Select(c => c.Rank).Distinct().Count();
        //private int DistinctSuits => Cards.Select(c => c.Suit).Distinct().Count();

        //private List<Card> GetCards()
        //{
        //    List <Card> cards = new List<Card>();
        //    Random rnd = new Random();
        //    int cardCount = 0;
        //    while (cardCount < 5)
        //    {
        //        Card card = new Card(rnd.Next(0, 51));
        //        if (!cards.Contains(card))
        //        {
        //            cards.Add(card);
        //            cardCount++;
        //        }
        //    }
        //    return cards.OrderBy(c => c.Rank).ThenBy(c => c.Suit).ToList();
        //}

        //private string DetermineHand()
        //{
        //    string name = "High Card";
        //    if (IsRoyalFlush) { name = "Royal Flush"; }
        //    if (IsStraightFlush) { name = "Straight Flush"; }
        //    if (IsQuads) { name = "Quads"; }
        //    if (IsFullHouse) { name = "Full House"; }
        //    if (IsFlush) { name = "Flush"; }
        //    if (IsStraight) { name = "Straight"; }
        //    if (IsStraightAceLow) { name = "Straight, Ace Low"; }
        //    if (IsTrips) { name = "Trips"; }
        //    if (IsTwoPair) { name = "Two Pair"; }
        //    if (IsPair) { name = "Pair"; }
        //    return name;
        //}
        //private bool FindMatchingCards(int n)
        //{
        //    bool found = false;
        //    int i = 0, targetIndex = 5 - n;
        //    while (!found && i <= targetIndex)
        //    {
        //        found = Instances(Cards.ToList()[i++].Rank) == n;
        //    }
        //    return found;
        //}

        //private int Instances(int rank)
        //{
        //    return Cards.Where(c => c.Rank == rank).Count();
        //}

    }
}
