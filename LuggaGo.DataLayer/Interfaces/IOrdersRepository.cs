using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuggaGo.DataLayer.Models.Interfaces
{
    public interface IOrdersRepository : IGenericRepository<Order>
    {
        Order FindByID(int ID);
        Order FindByFlightNumber(string flightNumber);
    }
}
