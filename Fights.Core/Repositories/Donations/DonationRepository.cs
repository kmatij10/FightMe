using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Fights.Data.Database;
using Fights.Data.Entities;

namespace Fights.Core.Repositories.Donations
{
    public class DonationRepository : IDonationRepository
    {
        private readonly FightsContext context;

        public DonationRepository(FightsContext context) => this.context = context;
        public Donation Create(Donation entity)
        {
            this.context.Donations.Add(entity);
            this.context.SaveChanges();
            return entity;
        }

        public bool Delete(long id)
        {
            this.context.Donations.Remove(
                this.GetOne(id)
            );
            this.context.SaveChanges();
            return true;
        }

        public IEnumerable<Donation> GetAll(string search)
        {
            var result = this.context.Donations.ToList();
            return result;
        }

        public Donation GetOne(long id) => this.context.Donations
            .Where(o => o.Id == id)
            .First<Donation>();

        public Donation Update(long id, Donation entity)
        {
            entity.Id = id;
            this.context.Entry(entity).State = EntityState.Modified;
            this.context.SaveChanges();
            return this.GetOne(id);
        }
    }
}