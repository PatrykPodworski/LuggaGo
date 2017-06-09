using LuggaGo.DataLayer.Models.Interfaces;
using LuggaGo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuggaGo.DataLayer.Models.Repositories
{
    public class OrdersRepository : GenericRepository<LuggagoDbContext, Order>,
        IOrdersRepository
    {
        public Order FindByFlightNumber(string flightNumber)
        {
            var query = GetAll().FirstOrDefault(x =>
                x.FlightNumber == flightNumber);
            return query;
        }

        public Order FindByID(int ID)
        {
            var query = GetAll().FirstOrDefault(x => x.ID == ID);
            return query;
        }
    }
}
