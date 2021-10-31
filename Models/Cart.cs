using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public string CartNumber { get; set; }
        public string Email { get; set; }
        public bool isChecked { get; set; }

        public Product Product { get; set; }
        public List<Product> Products { get; set; }
    }
}
