using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Fights.Data.Database;
using Fights.Data.Entities;

namespace Fights.Core.Repositories.Swipes
{
    public class SwipeRepository : ISwipeRepository
    {
        private readonly FightsContext context;

        public SwipeRepository(FightsContext context) => this.context = context;
        public Swipe Create(Swipe entity)
        {
            this.context.Swipes.Add(entity);
            this.context.SaveChanges();
            return entity;
        }

        public bool Delete(long id)
        {
            this.context.Swipes.Remove(
                this.GetOne(id)
            );
            this.context.SaveChanges();
            return true;
        }

        public IEnumerable<Swipe> GetAll(string search)
        {
            var result = this.context.Swipes.ToList();
            return result;
        }

        public Swipe GetOne(long id) => this.context.Swipes
            .Where(o => o.Id == id)
            .First<Swipe>();

        public Swipe Update(long id, Swipe entity)
        {
            entity.Id = id;
            this.context.Entry(entity).State = EntityState.Modified;
            this.context.SaveChanges();
            return this.GetOne(id);
        }
    }
}