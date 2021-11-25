using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
/*        public Address Address { get; set; }
        public Structure Structure { get; set; }
        public Team Team { get; set; }*/
    }
}

