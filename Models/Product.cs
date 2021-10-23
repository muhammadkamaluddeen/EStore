using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [DisplayName("Product Name")]
        [Required]
      
        public string ProductName { get; set; }
        [DisplayName("Short Description")]
        public string ShortDesc { get; set; }
        [DisplayName("Detail Description")]
        public string LongDesc { get; set; }
        public decimal Price { get; set; }
        [DisplayName("Product Image")]
        public string ImagePath{ get; set; }
        
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }
      

        [DisplayName("Product of the Week")]
        public bool IsProductOfTheWeek { get; set; }
        [DisplayName("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
 