using LuggaGo.DataLayer.Models;
using LuggaGo.DataLayer.Repositories;

namespace LuggaGo.BusinessLayer
{
   public class UserServices
   {
       private readonly UserRepository _userRepository;

       public UserServices(UserRepository userRepository)
       {
           _userRepository = userRepository;
       }

       public void AddUser(string firstName, string lastName, string accountId)
        {
            var user = new User(firstName, lastName, accountId);
            _userRepository.Add(user);
        }
    }
}
