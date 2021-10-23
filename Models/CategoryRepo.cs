using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Models
{
    public class CategoryRepo : ICategory
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Category> AllCategories => _appDbContext.Categories;
       
    }
}
