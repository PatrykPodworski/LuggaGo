using LuggaGo.DataLayer.Models;

namespace LuggaGo.DataLayer.Interfaces
{
    public interface IOrdersRepository : IGenericRepository<Order>
    {
        Order FindById(int id);
        Order FindByFlightNumber(string flightNumber);
    }
}
