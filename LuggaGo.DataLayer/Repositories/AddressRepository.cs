using LuggaGo.DataLayer.Models.Interfaces;
using LuggaGo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuggaGo.DataLayer.Models.Repositories
{
    public class AddressRepository : GenericRepository<LuggagoDbContext,
        Address>, IAddressRepository
    {
        public Address FindByCity(string city)
        {
            // may change - there can be more addresses with the same city
            var query = GetAll().FirstOrDefault(x => x.City == city);
            return query;
        }

        public Address FindByID(int addressID)
        {
            var query = GetAll().FirstOrDefault(x => x.ID == addressID);
            return query;
        }

        public Address FindByName(string name)
        {
            var query = GetAll().FirstOrDefault(x => x.Name == name);
            return query;
        }

        public Address FindByPostalCode(string postalCode)
        {
            var query = GetAll().FirstOrDefault(x => x.PostalCode == postalCode);
            return query;
        }

        public Address FindByStreet(string street)
        {
            var query = GetAll().FirstOrDefault(x => x.Street == street);
            return query;
        }
    }
}
