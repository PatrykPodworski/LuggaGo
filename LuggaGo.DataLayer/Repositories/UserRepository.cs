using LuggaGo.DataLayer.Models;
using LuggaGo.DataLayer.Models.Repositories;
using System.Linq;
using LuggaGo.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace LuggaGo.DataLayer.Repositories
{
    public class UserRepository : GenericRepository<LuggagoDbContext, User>,
        IUserRepository
    {
        public User FindByAccountId(string accountId)
        {
            return GetAll().FirstOrDefault(x => x.AccountId == accountId);
        }

        public User FindById(int ID)
        {
            var query = GetAll().FirstOrDefault(x => x.ID == ID);
            return query;
        }

        public User FindByName(string name)
        {
            var query = GetAll().FirstOrDefault(x => x.Name == name);
            return query;
        }

        public List<Address> GetAddresses(string accountId)
        {
            var query = GetAll()
                .Include(x => x.Addresses)
                .FirstOrDefault(x => x.AccountId == accountId);
            return query.Addresses;
        }

        public CreditCard GetCreditCardById(int id, string accountId)
        {
            var query = GetAll()
                .Include(x => x.CreditCards)
                .FirstOrDefault(x => x.AccountId == accountId)
                .CreditCards
                .FirstOrDefault(y => y.Id == id);
            return query;
        }

        public List<CreditCard> GetCreditCards(string accountId)
        {
            var query = GetAll()
                .Include(x => x.CreditCards)
                .FirstOrDefault(x => x.AccountId == accountId);
            return query.CreditCards;
        }

        public Address GetUserAddressById(int id, string accountId)
        {
            var query = GetAll()
                .Include(x => x.Addresses)
                .FirstOrDefault(x => x.AccountId == accountId);

            var result = query.Addresses.FirstOrDefault(y => y.ID == id);

            return result;
        }

        public List<Order> GetUserOrders(string accountId)
        {
            var query = GetAll()
                .Include(x => x.Orders)
                .Include(x => x.Orders.Select(y => y.Paths.Select(z => z.FromAddress)))
                .Include(x => x.Orders.Select(y => y.Paths.Select(z => z.ToAddress)))
                .FirstOrDefault(x => x.AccountId == accountId);
            return query?.Orders;
        }
    }
}
