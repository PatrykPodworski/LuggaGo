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


namespace LuggaGo.Controllers
{   
    
    [RoutePrefix("api/OrdersServices")]
    public class OrderController:ApiController
    {

        private OrdersServices _ordersServices;

        public OrdersServices OrdersServices
        {
            get
            {
                return _ordersServices ?? new OrdersServices(new OrdersRepository());

            }
            private set { _ordersServices = value; }
        }

        [HttpPost]
        [Route("GetOrderPrice")]
        public async Task<decimal?> GetOrderPrice(Order order)
        {

             return await OrdersServices.GetOrderPrice(order);

        }

        [HttpPost]
        [Route("PlaceOrder")]
        public async Task<IHttpActionResult> PlaceOrder(Order order)
        {
            if (await OrdersServices.PlaceOrder(order))
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
            return OrdersServices.GetAllOrders();
        }

        
    }
}