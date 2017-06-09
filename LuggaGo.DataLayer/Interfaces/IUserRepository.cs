using LuggaGo.DataLayer.Models;
using System.Collections.Generic;

namespace LuggaGo.DataLayer.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User FindById(int id);
        User FindByName(string name);
        User FindByAccountId(string accountId);
        List<Address> GetAddresses(string accountId);
        Address GetUserAddressById(int id, string accountId);
        List<CreditCard> GetCreditCards(string accountId);
        CreditCard GetCreditCardById(int id, string accountId);
    }
}
