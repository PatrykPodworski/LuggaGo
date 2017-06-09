using LuggaGo.DataLayer.Interfaces;
using LuggaGo.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuggaGo.BusinessLayer
{
    public class AddressServices
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IUserRepository _userRepository;

        public AddressServices(IAddressRepository addressRepository,
            IUserRepository userRepository)
        {
            _addressRepository = addressRepository;
            _userRepository = userRepository;
        }

        public bool AddAddress(Address address, string accountId)
        {
            var user = _userRepository.FindByAccountId(accountId);

            if (user == null)
                return false;

            //_addressRepository.Add(address);
            user.Addresses.Add(address);
            _userRepository.Save();

            return true;
        }

        public bool Edit(Address address, string accountId)
        {
            var userAddress = _userRepository.GetUserAddressById(address.ID, 
                accountId);

            if (userAddress == null)
                return false;

            userAddress.City = address.City;
            userAddress.Name = address.Name;
            userAddress.PostalCode = address.PostalCode;
            userAddress.Street = address.Street;

            _addressRepository.Edit(userAddress);
            _addressRepository.Save();

            return true;
        }

        public List<Address> GetAddresses(string accountId)
        {
            var addresses = _userRepository.GetAddresses(accountId);

            return addresses;
        }
    }
}
