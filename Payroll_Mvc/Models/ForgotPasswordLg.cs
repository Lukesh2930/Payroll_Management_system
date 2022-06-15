using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Payroll_Mvc.Models
{
    public class ForgotPasswordLg
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string New_Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string conform_password { get; set; }

    }
}