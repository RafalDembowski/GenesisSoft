using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public ProductCategory Category { get; set; }
        public Producer Producer { get; set; }
    }
}
