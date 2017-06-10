using System.Collections.Generic;
using System.Linq;
using LuggaGo.DataLayer.Models;
using LuggaGo.DataLayer.Interfaces;

namespace LuggaGo.BusinessLayer
{
    public class UserServices
   {
       private readonly IUserRepository _userRepository;

       public UserServices(IUserRepository userRepository)
       {
           _userRepository = userRepository;
       }

       public void AddUser(string firstName, string lastName, string accountId)
       {
            var user = new User(firstName, lastName, accountId);
            _userRepository.Add(user);
            _userRepository.Save();
       }

       public List<User> GetAll()
       {
           return _userRepository.GetAll().ToList();
       }

       public bool Edit(User model, string accountId)
       {
            var user = _userRepository.FindByAccountId(accountId);

            if (user == null)
                return false;

            user.Addresses = model.Addresses;
            user.CreditCards = model.CreditCards;
            user.Name = model.Name;
            user.Orders = model.Orders;

            _userRepository.Edit(user);
            _userRepository.Save();

            return true;
       }
   }
}
