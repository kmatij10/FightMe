using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Fights.Data.Database;
using Fights.Data.Entities;

namespace Fights.Core.Repositories.Fights
{
    public class FightRepository : IFightRepository
    {
        private readonly FightsContext context;

        public FightRepository(FightsContext context) => this.context = context;
        public Fight Create(Fight entity)
        {
            this.context.Fights.Add(entity);
            this.context.SaveChanges();
            return entity;
        }

        public bool Delete(long id)
        {
            this.context.Fights.Remove(
                this.GetOne(id)
            );
            this.context.SaveChanges();
            return true;
        }

        public IEnumerable<Fight> GetAll(string search)
        {
            var result = this.context.Fights.ToList();
            return result;
        }

        public Fight GetOne(long id)=> this.context.Fights
            .Where(o => o.Id == id)
            .First<Fight>();

        public Fight Update(long id, Fight entity)
        {
            entity.Id = id;
            this.context.Entry(entity).State = EntityState.Modified;
            this.context.SaveChanges();
            return this.GetOne(id);
        }
    }
}