using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuggaGo.DataLayer.Models.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User FindByID(int ID);
        User FindByName(string name);
    }
}
