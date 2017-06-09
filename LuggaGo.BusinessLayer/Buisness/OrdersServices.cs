using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using LuggaGo.DataLayer.Models.Interfaces;
using LuggaGo.DataLayer.Models.Repositories;
using LuggaGo.Models;

namespace LuggaGo.BusinessLayer.Buisness
{
    public class OrdersServices
    {
        private static IOrdersRepository _ordersRepository;

        public OrdersServices(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public static  async Task<decimal?> GetOrderPrice(Order ord)
        {
            bool res = await IsOrderCorrect(ord);
            if (!res)
            {
                return null;
            }
            return GetPrice();
        }

        public static Task<bool> PlaceOrder(Order order)
        {
            try
            {
                _ordersRepository.Add(order);
                return Task.FromResult(true);
            }
            catch (NullReferenceException e)
            {
                return Task.FromResult(false);
            }
        }
        private static Task<bool> IsOrderCorrect(Order order)
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

        private static bool IsPathCorrect(Path path)
        {
            if (path.FromAddress == path.ToAddress) return false;
            if (path.FromAddress == null || path.ToAddress == null) return false;
            return true;
        }

        private static decimal GetPrice()
        {
            
                Random rand = new Random();
                return rand.Next() % 50 + 10;
            
        }
    }
}
