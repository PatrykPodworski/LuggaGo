using System.Collections.Generic;

namespace LuggaGo.DataLayer.Models
{
    public class Order
    {
        public int ID { get; set; }
        public string FlightNumber { get; set; }
        public List<Path> Paths { get; set; }
        public int LuggageWeight { get; set; }
        public Dimensions LuggageDimensions { get; set; }
        public decimal Price { get; set; }

        public Order()
        {
            Paths = new List<Path>();
        }

        public Order(string flightNumber, int luggageWeight, 
            Dimensions luggageDimensions, decimal price)
        {
            FlightNumber = flightNumber;
            LuggageWeight = luggageWeight;
            LuggageDimensions = luggageDimensions;
            Price = price;
        }
    }
}