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
    public class CarController : Controller
    {
        private readonly ICarRepository _CarRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CarController(ICarRepository CarRepository, ICategoryRepository categoryRepository)
        {
            _CarRepository = CarRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Car> Cars;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                Cars = _CarRepository.Cars.OrderBy(p => p.CarId);
                currentCategory = "All Cars";
            }
            else
            {
                if (string.Equals("Alcoholic", _category, StringComparison.OrdinalIgnoreCase))
                    Cars = _CarRepository.Cars.Where(p => p.Category.CategoryName.Equals("Alcoholic")).OrderBy(p => p.Name);
                else
                    Cars = _CarRepository.Cars.Where(p => p.Category.CategoryName.Equals("Non-alcoholic")).OrderBy(p => p.Name);

                currentCategory = _category;
            }

            return View(new CarsListViewModel
            {
                Cars = Cars,
                CurrentCategory = currentCategory
            });
        }

        public ViewResult Search(string searchString)
        {
            string _searchString = searchString;
            IEnumerable<Car> Cars;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(_searchString))
            {
                Cars = _CarRepository.Cars.OrderBy(p => p.CarId);
            }
            else
            {
                Cars = _CarRepository.Cars.Where(p=> p.Name.ToLower().Contains(_searchString.ToLower()));
            }

            return View("~/Views/Car/List.cshtml", new CarsListViewModel{Cars = Cars, CurrentCategory = "All Cars" });
        }

        public ViewResult Details(int CarId)
        {
            var Car = _CarRepository.Cars.FirstOrDefault(d => d.CarId == CarId);
            if (Car == null)
            {
                return View("~/Views/Error/Error.cshtml");
            }
            return View(Car);
        }
    }
}
