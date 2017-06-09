using LuggaGo.DataLayer.Models;

namespace LuggaGo.DataLayer.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User FindById(int id);
        User FindByName(string name);
    }
}
