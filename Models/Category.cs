using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace EStore.Models
{
    public class Category
    {
        [DisplayName("Category Id")]
        public int CategoryId { get; set; }
        [DisplayName("Category Name")]
        [Required(ErrorMessage="Category Name cannot be empty!")]
        
        public string CategoryName { get; set; }
 
        [Required]
       
        public string Description { get; set; }
        [DisplayName("Status")]
        public bool ActiveStatus { get; set; }
        public List<Product> Products { get; set; }
    }
}
