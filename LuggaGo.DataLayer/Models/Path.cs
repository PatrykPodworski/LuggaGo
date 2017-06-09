namespace LuggaGo.DataLayer.Models
{
    public class Path
    {
        public int ID { get; set; }
        public Address FromAddress { get; set; }
        public Address ToAddress { get; set; }

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