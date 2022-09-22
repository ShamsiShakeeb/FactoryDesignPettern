using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModel
{
    public class LoginViewModel
    {
        [Display (Name = "User Name")]
        [DataType(DataType.Text)]
        public string UserName { set; get; }
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { set; get; }
    }
}
