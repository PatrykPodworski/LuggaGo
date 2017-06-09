using LuggaGo.DataLayer.Models;
using LuggaGo.DataLayer.Models.Interfaces;
using LuggaGo.DataLayer.Models.Repositories;
using System.Linq;

namespace LuggaGo.DataLayer.Repositories
{
    public class UserRepository : GenericRepository<LuggagoDbContext, User>,
        IUserRepository
    {
        public User FindByID(int ID)
        {
            var query = GetAll().FirstOrDefault(x => x.ID == ID);
            return query;
        }

        public User FindByName(string name)
        {
            var query = GetAll().FirstOrDefault(x => x.Name == name);
            return query;
        }
    }
}
