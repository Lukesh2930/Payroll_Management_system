using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Payroll_Mvc.Models
{
    public class Signup
    {
       
        [Required]
        public int User_id { get; set; }
        [Required]
       
        public string User_Name { get; set; }
        [Required]
       
        public Nullable<int> Age { get; set; }
        [Required]
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        
        public string Password { get; set; }
    }
}