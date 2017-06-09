using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuggaGo.DataLayer.Interfaces;
using LuggaGo.DataLayer.Models;

namespace LuggaGo.BusinessLayer
{
    public class AirportServices
    {
        private IAirportRepository _airportRepository;

        public AirportServices(IAirportRepository airportRepository)
        {
            _airportRepository = airportRepository;
        }

        public Task<bool> AddAirport(Airport airport)
        {
            _airportRepository.Add(airport);
            _airportRepository.Save();
            return Task.FromResult(true);
        }

        public Task<bool> AddAirports(List<Airport> airports)
        {
            foreach (var a in airports)
            {
                if (!IsAirportCorrect(a))
                    return Task.FromResult(false);
                
            }
            foreach (var a in airports)
            {
                _airportRepository.Add(a);
               
            }
            _airportRepository.Save();
            return Task.FromResult(true);
        }

        public bool IsAirportCorrect(Airport airport)
        {
            if (airport.Address == null) return false;
            if (airport.Name == null) return false;
            if (airport.ShortName == null) return false;
            return true;
        }

        public Airport GetAirportById(int id)
        {
            return _airportRepository.FindById(id);
        }

        public List<Airport> GetAllAirports()
        {
            return _airportRepository.GetAll().ToList();
        }
    }
}
