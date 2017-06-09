using LuggaGo.DataLayer.Models;
using LuggaGo.DataLayer.Models.Repositories;
using System.Linq;
using LuggaGo.DataLayer.Interfaces;

namespace LuggaGo.DataLayer.Repositories
{
    public class UserRepository : GenericRepository<LuggagoDbContext, User>,
        IUserRepository
    {
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
    }
}
