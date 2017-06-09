using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuggaGo.DataLayer.Models.Interfaces
{
    interface IAddressRepository : IGenericRepository<Address>
    {
        Address FindByID(int addressID);
        Address FindByName(string name);
        Address FindByCity(string city);
        Address FindByStreet(string street);
        Address FindByPostalCode(string postalCode);
    }
}
