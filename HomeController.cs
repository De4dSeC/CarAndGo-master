using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarAndGo.Data.Interfaces;
using CarAndGo.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CarAndGo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarRepository _CarRepository;
        public HomeController(ICarRepository CarRepository)
        {
            _CarRepository = CarRepository;
        }

        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                PreferredCars = _CarRepository.PreferredCars
            };
            return View(homeViewModel);
        }
    }
}
