using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuggaGo.Models
{
    public class Path
    {
        public Address FromAddress { get; set; }
        public Address ToAddress { get; set; }
        public int ID { get; set; }

        public Path()
        {

        }

        public Path(Address fromAddress, Address toAddress)
        {
            FromAddress = fromAddress;
            ToAddress = toAddress;
        }
    }
}