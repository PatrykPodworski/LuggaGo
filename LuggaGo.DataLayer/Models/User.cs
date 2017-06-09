using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuggaGo.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Order> Orders { get; set; }

        public User()
        {
            Addresses = new List<Address>();
            Orders = new List<Order>();
        }

        public User(string firstName, string lastName) : this()
        {
            Name = firstName + " " + lastName;
        }
    }
}