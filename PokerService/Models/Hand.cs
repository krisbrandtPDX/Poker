using System;
namespace PokerService.Models
{
    public class Hand
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
