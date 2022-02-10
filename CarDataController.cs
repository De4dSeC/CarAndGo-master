using CarAndGo.Data.Interfaces;
using CarAndGo.Data.Models;
using CarAndGo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAndGo.Controllers
{
    [Route("api/[controller]")]
    public class CarDataController : Controller
    {
        private readonly ICarRepository _CarRepository;

        public CarDataController(ICarRepository CarRepository)
        {
            _CarRepository = CarRepository;
        }

        [HttpGet]
        public IEnumerable<CarViewModel> LoadMoreCars()
        {
            IEnumerable<Car> dbCars = null;

            dbCars = _CarRepository.Cars.OrderBy(p => p.CarId).Take(10);

            List<CarViewModel> Cars = new List<CarViewModel>();

            foreach (var dbCar in dbCars)
            {
                Cars.Add(MapDbCarToCarViewModel(dbCar));
            }
            return Cars;
        }

        private CarViewModel MapDbCarToCarViewModel(Car dbCar) => new CarViewModel()
        {
            CarId = dbCar.CarId,
            Name = dbCar.Name,
            Price = dbCar.Price,
            ShortDescription = dbCar.ShortDescription,
            ImageThumbnailUrl = dbCar.ImageThumbnailUrl
        };

    }
}
