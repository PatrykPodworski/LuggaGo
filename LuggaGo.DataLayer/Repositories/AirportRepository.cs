using LuggaGo.DataLayer.Models.Interfaces;
using LuggaGo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuggaGo.DataLayer.Models.Repositories
{
    public class AirportRepository : GenericRepository<LuggagoDbContext,
        Airport>, IAirportRepository
    {
        public Airport FindByID(int airportID)
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
    }
}
