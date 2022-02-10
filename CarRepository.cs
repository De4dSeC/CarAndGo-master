using CarAndGo.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarAndGo.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CarAndGo.Data.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDbContext _appDbContext;
        public CarRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Car> Cars => _appDbContext.Cars.Include(c => c.Category);

        public IEnumerable<Car> PreferredCars => _appDbContext.Cars.Where(p => p.IsPreferredCar).Include(c => c.Category);

        public Car GetCarById(int CarId) => _appDbContext.Cars.FirstOrDefault(p => p.CarId == CarId);
    }
}
