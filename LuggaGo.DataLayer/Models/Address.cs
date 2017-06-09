namespace LuggaGo.DataLayer.Models
{
    public class Address
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }

        public Address()
        {

        }

        public Address(string name, string city, string street, 
            string postalCode)
        {
            Name = name;
            City = city;
            Street = street;
            PostalCode = postalCode;
        }
    }
}