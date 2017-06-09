using LuggaGo.DataLayer.Models;

namespace LuggaGo.DataLayer.Interfaces
{
    public interface IAirportRepository : IGenericRepository<Airport>
    {
        Airport FindById(int airportId);
        Airport FindByName(string name);
        Airport FindByShort(string shortName);
    }
}
