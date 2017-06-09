using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuggaGo.Models
{
    public class Airport
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public Address Address { get; set; }

        public Airport()
        {

        }

        public Airport(string name, Address address)
        {
            Name = name;
            Address = address;
        }
    }
}