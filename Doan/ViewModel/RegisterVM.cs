using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Doan.ViewModel
{
    public class RegisterVM
    {
        [Required(ErrorMessage="UserName can't be blank!!!" )]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password can't be blank!!!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "ConfirmPassword can't be blank!!!")]
        [Compare("Password",ErrorMessage ="Password and ConfirmPassword do not match")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage ="Email can't be blank!!!")]
        [EmailAddress(ErrorMessage ="Invalid Email")]
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }
    }
}