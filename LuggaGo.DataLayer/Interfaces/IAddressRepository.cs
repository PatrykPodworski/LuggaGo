using LuggaGo.DataLayer.Models;

namespace LuggaGo.DataLayer.Interfaces
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        Address FindById(int addressId);
        Address FindByName(string name);
        Address FindByCity(string city);
        Address FindByStreet(string street);
        Address FindByPostalCode(string postalCode);
    }
}
