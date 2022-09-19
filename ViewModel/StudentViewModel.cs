using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModel
{
    public class StudentViewModel 
    {
        public string Name { set; get; }
        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        [RegularExpression(@"^[_a-zA-Z0-9-]+(\.[_a-zA-Z0-9-]+)*@[a-zA-Z0-9-]+(\.[a-zA-Z0-9-]+)*\.(([0-9]{1,3})|([a-zA-Z]{2,3})|(aero|coop|info|museum|name))$", ErrorMessage = "Email is not valid")]
        public string Email { set; get; }
        [Required]
        [MaxLength(250)]
        [MinLength(6)]
        //[RegularExpression(@"\d{1,3}.?\d{0,3}\s[a-zA-Z]{2,30}\s[a-zA-Z]{2,15}", ErrorMessage = "Address is not valid")]
        public string Address { set; get; }
        [Required]
        public double Cgpa { set; get; }
    }
}
