using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

using LuggaGo.BusinessLayer.Buisness;
using LuggaGo.DataLayer.Interfaces;
using LuggaGo.DataLayer.Models;
using LuggaGo.DataLayer.Models.Repositories;
using LuggaGo.DataLayer.Repositories;
using Microsoft.AspNet.Identity;


namespace LuggaGo.Controllers
{   
    [Authorize]
    [RoutePrefix("api/OrdersServices")]
    public class OrderController:ApiController
    {

        private OrdersServices _ordersServices;

        public OrdersServices OrdersServices
        {
            get
            {
                return _ordersServices ?? new OrdersServices(
                    new OrdersRepository()
                    ,new UserRepository());

            }
            private set { _ordersServices = value; }
        }

        [HttpPost]
        [Route("GetOrderPrice")]
        public async Task<decimal?> GetOrderPrice(Order order)
        {

            var accountId = User.Identity.GetUserId();
            return await OrdersServices.GetOrderPrice(order,accountId);

        }

        [HttpPost]
        [Route("PlaceOrder")]
        public async Task<IHttpActionResult> PlaceOrder(Order order)
        {
            var accountId = User.Identity.GetUserId();
            if (await OrdersServices.PlaceOrder(order,accountId))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetAllOrders")]

        public List<Order> GetAllOrders()
        {
            var accountId = User.Identity.GetUserId();
            return OrdersServices.GetAllOrders(accountId);
        }

        
    }
}