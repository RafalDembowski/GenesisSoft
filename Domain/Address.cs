using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Address
    {
        public Guid Id { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public string ZIPCode { get; set; }
    }
}
