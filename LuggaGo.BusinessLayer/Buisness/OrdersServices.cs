using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using LuggaGo.DataLayer.Interfaces;
using LuggaGo.DataLayer.Models;

using LuggaGo.DataLayer.Models.Repositories;


namespace LuggaGo.BusinessLayer.Buisness
{
    public class OrdersServices
    {
        private IOrdersRepository _ordersRepository;

        public OrdersServices(IOrdersRepository ordersRepository)
        {
          _ordersRepository = ordersRepository;
        }

        public   async Task<decimal?> GetOrderPrice(Order ord)
        {
            bool res = await IsOrderCorrect(ord);
            if (!res)
            {
                return null;
            }
            return GetPrice();
        }

        public  Task<bool> PlaceOrder(Order order)
        {
            try
            {
                _ordersRepository.Add(order);
                _ordersRepository.Save();
                return Task.FromResult(true);
            }
            catch (NullReferenceException)
            {
                return Task.FromResult(false);
            }
        }

        public List<Order> GetAllOrders()
        {
            return _ordersRepository.GetAll().ToList();
        }

        private Task<bool> IsOrderCorrect(Order order)
        {
            if (order.FlightNumber == null) return Task.FromResult(false);
            if (order.LuggageDimensions == null) return Task.FromResult(false);
            if (order.LuggageWeight <= 0)  return Task.FromResult(false);
            if (order.Price < 0)  return Task.FromResult(false);
            foreach (var path in order.Paths)
            {
                if (!IsPathCorrect(path)) return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }

        private  bool IsPathCorrect(Path path)
        {
            if (path.FromAddress == path.ToAddress) return false;
            if (path.FromAddress == null || path.ToAddress == null) return false;
            return true;
        }

        private  decimal GetPrice()
        {
            
                Random rand = new Random();
                return rand.Next() % 50 + 10;
            
        }
    }
}
