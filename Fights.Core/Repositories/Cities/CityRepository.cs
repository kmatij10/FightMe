using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Fights.Data.Database;
using Fights.Data.Entities;
namespace Fights.Core.Repositories.Cities
{
    public class CityRepository : ICityRepository
    {
        private readonly FightsContext context;

        public CityRepository(FightsContext context) => this.context = context;
        
        public City Create(City entity)
        {
            this.context.Cities.Add(entity);
            this.context.SaveChanges();
            return entity;
        }

        public bool Delete(long id)
        {
            this.context.Cities.Remove(
                this.GetOne(id)
            );
            this.context.SaveChanges();
            return true;
        }

        public IEnumerable<City> GetAll(string search)
        {
            var result = this.context.Cities.ToList();
            return result;
        }

        public City GetOne(long id) => this.context.Cities
            .Where(o => o.Id == id)
            .First<City>();

        public City Update(long id, City entity)
        {
            entity.Id = id;
            this.context.Entry(entity).State = EntityState.Modified;
            this.context.SaveChanges();
            return this.GetOne(id);
        }
    }
}