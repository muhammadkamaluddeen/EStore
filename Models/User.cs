using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Models
{
    public class User
    {

        public int UserId { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        
        [Display(Name ="Confirm Password")]
        [NotMapped]
        public string ConfirmPassword { get; set; }
        public string UserType { get; set; }

     
    }
}
