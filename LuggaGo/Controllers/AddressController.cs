using LuggaGo.BusinessLayer;
using LuggaGo.DataLayer.Models;
using LuggaGo.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using System.Web.Routing;

namespace LuggaGo.Controllers
{
    [Authorize]
    [RoutePrefix("api/Address")]
    public class AddressController : ApiController
    {
        private AddressServices _addressServices;

        public AddressServices AddressServices
        {
            get
            {
                return _addressServices ?? new AddressServices(
                    new AddressRepository(), new UserRepository());

            }
            private set { _addressServices = value; }
        }

        [HttpPost]
        [Route("Add")]
        public IHttpActionResult Add(Address model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accountId = User.Identity.GetUserId();

            var success = AddressServices.AddAddress(model, accountId);

            if(success)
                return Ok();
            return BadRequest();
        }

        [HttpGet]
        [Route("Get")]
        public List<Address> Get()
        {
            var accountId = User.Identity.GetUserId();

            return AddressServices.GetAddresses(accountId);
        }

        [HttpPut]
        //[Route("Edit")]
        public IHttpActionResult Edit(int id, [FromBody]Address address)
        {
            var accountId = User.Identity.GetUserId();
            address.ID = id;
            var success = AddressServices.Edit(address, accountId);

            if (!success)
                return BadRequest();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var accountId = User.Identity.GetUserId();
            var success = AddressServices.Delete(id, accountId);

            if (!success)
                return BadRequest();
            return Ok();
        }
    }
}
