using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Commission : Entity
    {
        public float TotalAmount { get; set; }
        public int PercentageShare { get; set; }
        public User Employee { get; set; }
        public Contract Contract { get; set; }
    }
}
