using LuggaGo.DataLayer.Interfaces;
using LuggaGo.DataLayer.Models;
using LuggaGo.DataLayer.Models.Repositories;

namespace LuggaGo.DataLayer.Repositories
{
    public class PaymentRepository : GenericRepository<LuggagoDbContext,
        CreditCard>, IPaymentRepository
    {
    }
}
