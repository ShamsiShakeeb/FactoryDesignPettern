using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class ApplicationUser : IdentityUser
    {
        public int Age { get; set; }
        public string Address { set; get; }
    }
}
