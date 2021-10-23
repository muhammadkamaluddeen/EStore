using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Models
{
    public class ProductRepo : IProduct
    {
        private readonly AppDbContext _appDbContext;
        public ProductRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Product> AllProducts
        {

            get
            {

                // return _appDbContext.Products;

                return _appDbContext.Products.Include(c => c.Category);

                //_appDbContext
            }
        }

        public IEnumerable<Product> ProductsOfTheWeek
        {
            get
            {
                return _appDbContext.Products.Include(c => c.Category).Where(p => p.IsProductOfTheWeek);
            }
        }
        public Product GetProductById(int productId)
        {
            return _appDbContext.Products.FirstOrDefault(p => p.ProductId == productId);
        }
    }
}
