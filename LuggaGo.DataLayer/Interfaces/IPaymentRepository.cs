using LuggaGo.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuggaGo.DataLayer.Interfaces
{
    public interface IPaymentRepository : IGenericRepository<CreditCard>
    {
    }
}
