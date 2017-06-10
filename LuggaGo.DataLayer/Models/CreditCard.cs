namespace LuggaGo.DataLayer.Models
{
    public class CreditCard
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string OwnerName { get; set; }
        public string CVVCode { get; set; }

        public CreditCard()
        {

        }

        public CreditCard(string cardNumber, string expirationDate,
            string ownerName, string cvvCode)
        {
            CardNumber = cardNumber;
            ExpirationDate = expirationDate;
            OwnerName = ownerName;
            CVVCode = cvvCode;
        }
    }
}
