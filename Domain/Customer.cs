using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Source { get; set; }
        public bool Active { get; set; }
        public User Adviser { get; set; }
        public Address Address { get; set; }
    }
}

