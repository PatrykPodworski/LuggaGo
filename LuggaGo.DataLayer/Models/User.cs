using System.Collections.Generic;

namespace LuggaGo.DataLayer.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string AccountId { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Order> Orders { get; set; }
        public List<CreditCard> CreditCards { get; set; }

        public User()
        {
            Addresses = new List<Address>();
            Orders = new List<Order>();
            CreditCards = new List<CreditCard>();
        }

        public User(string firstName, string lastName, string accountId) : this()
        {
            Name = firstName + " " + lastName;
            AccountId = accountId;
        }
    }
}