using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuggaGo.DataLayer.Interfaces;

namespace LuggaGo.DataLayer.Models.Repositories
{
    public class AirportRepository : GenericRepository<LuggagoDbContext,
        Airport>, IAirportRepository
    {
        public Airport FindById(int airportID)
        {
            var query = GetAll().FirstOrDefault(x => x.ID == airportID);
            return query;
        }

        public Airport FindByName(string name)
        {
            var query = GetAll().FirstOrDefault(x => x.Name == name);
            return query;
        }

        public Airport FindByShort(string shortName)
        {
            var query = GetAll().FirstOrDefault(x => x.ShortName == shortName);
            return query;
        }

        public override IQueryable<Airport> GetAll()
        {
            var query = Context.Airports.Include(x=>x.Address);
            return query;
        }
    }
}
