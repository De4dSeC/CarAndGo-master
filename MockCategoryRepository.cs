using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarAndGo.Data.Interfaces;
using CarAndGo.Data.Models;

namespace CarAndGo.Data.Mocks
{
    public class MockCategoryRepository:ICategoryRepository
    {
        public IEnumerable<Category> Categories
        {
            get
            {
                return new List<Category>
                     {
                         new Category { CategoryName = "Alcoholic", Description = "All alcoholic Cars" },
                         new Category { CategoryName = "Non-alcoholic", Description = "All non-alcoholic Cars" }
                     };
            }
        }
    }
}
