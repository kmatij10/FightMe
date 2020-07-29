using System;

namespace Fights.Data.Entities
{
    public class Swipe : BaseEntity
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public long User1Id { get; set; }
        public long User2Id { get; set; }
        public int IsSuperSwipe { get; set; }
        // public User user1 { get; set; }
        // public User user2 { get; set; }
    }
}