﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Products
{
    public class ProductDto
    {
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public Guid ProducerId { get; set; }
    }
}
