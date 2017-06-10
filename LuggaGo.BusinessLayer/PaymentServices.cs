using LuggaGo.DataLayer.Models;
using LuggaGo.DataLayer.Interfaces;
using System.Collections.Generic;

namespace LuggaGo.BusinessLayer
{
    public class PaymentServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IPaymentRepository _paymentRepository;

        public PaymentServices(IUserRepository userRepository,
            IPaymentRepository paymentRepository)
        {
            _userRepository = userRepository;
            _paymentRepository = paymentRepository;
        }

        public bool AddPayment(CreditCard model, string accountId)
        {
            var user = _userRepository.FindByAccountId(accountId);

            if (user == null)
                return false;

            user.CreditCards.Add(model);
            _userRepository.Save();

            return true;
        }

        public List<CreditCard> Get(string accountId)
        {
            var creditCards = _userRepository.GetCreditCards(accountId);

            return creditCards;
        }

        public bool Edit(CreditCard model, string accountId)
        {
            var userCreditCard = _userRepository
                .GetCreditCardById(model.Id, accountId);

            if (userCreditCard == null)
                return false;

            userCreditCard.CardNumber = model.CardNumber;
            userCreditCard.CVVCode = model.CVVCode;
            userCreditCard.ExpirationDate = model.ExpirationDate;
            userCreditCard.OwnerName = model.OwnerName;

            _paymentRepository.Edit(userCreditCard);
            _paymentRepository.Save();

            return true;
        }

        public bool Delete(int id, string accountId)
        {
            var userCreditCard = _userRepository
                .GetCreditCardById(id, accountId);

            if (userCreditCard == null)
                return false;

            _paymentRepository.Delete(userCreditCard);
            _paymentRepository.Save();

            return true;
        }
    }
}
