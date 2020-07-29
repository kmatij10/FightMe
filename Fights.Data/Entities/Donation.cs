using System;

namespace Fights.Data.Entities
{
    public class Donation : BaseEntity
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public long UserId { get; set; }
        public long FightId { get; set; }
        public decimal Amount { get; set; }
        public Fight Fight { get; set; }
        // public User User { get; set; }
    }
}