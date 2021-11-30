using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Products
{
    public class ProductCommandDto
    {
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public Guid ProducerId { get; set; }
    }
}
