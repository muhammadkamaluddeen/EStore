using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Models
{
    public interface IProduct
    {
        IEnumerable<Product> AllProducts { get; }
        IEnumerable<Product> ProductsOfTheWeek { get; }
        Product GetProductById(int productId);
    }
}
