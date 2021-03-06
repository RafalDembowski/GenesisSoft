using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Products
{
    public class ProductQueryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ProducerName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}