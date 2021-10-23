using EStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Product> ProductsOfTheWeek { get; set; }
    }
}
