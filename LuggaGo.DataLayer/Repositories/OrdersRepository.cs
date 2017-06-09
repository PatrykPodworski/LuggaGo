using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuggaGo.DataLayer.Interfaces;

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

        public Order FindById(int ID)
        {
            var query = GetAll().FirstOrDefault(x => x.ID == ID);
            return query;
        }

        public override IQueryable<Order> GetAll()
        {
            var query = Context.Orders.Include(x => x.Paths.Select(y=>y.ToAddress)).
                Include(x => x.Paths.Select(y => y.FromAddress));
            return query;
        }


    }
}
