using LuggaGo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuggaGo.DataLayer.Models.Interfaces
{
    public interface IAirportRepository : IGenericRepository<Airport>
    {
        Airport FindByID(int airportID);
        Airport FindByName(string name);
        Airport FindByShort(string shortName);
    }
}
