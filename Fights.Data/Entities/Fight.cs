using System.Collections.Generic;

namespace Fights.Data.Entities
{
    public class Fight : BaseEntity
    {
        public string Address { get; set; }
        public long User1Id { get; set; }
        public long User2Id { get; set; }
        public long CityId { get; set; }
        public City City { get; set; }
        public ICollection<Donation> Donations { get; set; }
        // public User user1 { get; set; }
        // public User user2 { get; set; }
    }
}