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
        [RegularExpression("/^[a-zA-Z0-9.! #$%&'*+/=? ^_`{|}~-]+@[a-zA-Z0-9-]+(?:\\. [a-zA-Z0-9-]+)*$/",ErrorMessage = "Email is not valid")]
        public string Email { set; get; }
        [Required]
        [MaxLength(250)]
        [MinLength(6)]
        [RegularExpression("\\d{1,5}\\s\\w.\\s(\\b\\w*\\b\\s){1,2}\\w*\\.", ErrorMessage = "Address is not valid")]
        public string Address { set; get; }
        [Required]
        public double Cgpa { set; get; }
    }
}
