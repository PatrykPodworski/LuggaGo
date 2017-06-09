using LuggaGo.BusinessLayer;
using LuggaGo.DataLayer.Models;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using LuggaGo.DataLayer.Repositories;
using System.Collections.Generic;

namespace LuggaGo.Controllers
{
    [Authorize]
    [RoutePrefix("api/Payment")]
    public class PaymentController : ApiController
    {
        private PaymentServices _paymentServices;

        public PaymentServices PaymentServices
        {
            get
            {
                return _paymentServices ?? new PaymentServices(
                    new UserRepository(), new PaymentRepository());
            }
            private set { _paymentServices = value; }
        }

        [HttpPost]
        [Route("Add")]
        public IHttpActionResult Add(CreditCard model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accountId = User.Identity.GetUserId();

            var success = PaymentServices.AddPayment(model,
                accountId);

            if (!success)
                return BadRequest();
            return Ok();
        }

        [HttpGet]
        [Route("Get")]
        public List<CreditCard> Get()
        {
            var accountId = User.Identity.GetUserId();

            return PaymentServices.Get(accountId);
        }

        [HttpPut]
        public IHttpActionResult Edit(int id, [FromBody]CreditCard model)
        {
            var accountId = User.Identity.GetUserId();
            model.Id = id;
            var success = PaymentServices.Edit(model, accountId);

            if (!success)
                return BadRequest();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var accountId = User.Identity.GetUserId();
            var success = PaymentServices.Delete(id, accountId);

            if (!success)
                return BadRequest();
            return Ok();
        }
    }
}
