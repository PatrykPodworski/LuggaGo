using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using LuggaGo.BusinessLayer;
using LuggaGo.DataLayer.Models;
using LuggaGo.DataLayer.Models.Repositories;

namespace LuggaGo.Controllers
{
    [RoutePrefix("api/AirportServices")]
    public class AirportController:ApiController
    {
        private AirportServices _airportServices;


        public AirportServices AirportServices
        {
            get { return _airportServices ?? new AirportServices(new AirportRepository()); }
            private set { _airportServices = value; }
        }


        [HttpPost]
        [Route("AddAirport")]
        public async Task<IHttpActionResult> AddAirport(Airport airport)
        {
            if (await AirportServices.AddAirport(airport))
            {
                return Ok();
            }
            return BadRequest();
        }

        [Route("AddAirports")]
        public async Task<IHttpActionResult> AddAirports(List<Airport> airports)
        {
            if (await _airportServices.AddAirports(airports))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("GetAirportById")]
        public Airport GetAirportById(int id)
        {
            return _airportServices.GetAirportById(id);
        }

        [HttpGet]
        [Route("GetAllAirports")]
        public List<Airport> GetAllAirports()
        {
            return AirportServices.GetAllAirports();
        }


    }
}