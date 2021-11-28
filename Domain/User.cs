using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    /*pamieta o dodaniu struktury i zespolu*/
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
    }
}

