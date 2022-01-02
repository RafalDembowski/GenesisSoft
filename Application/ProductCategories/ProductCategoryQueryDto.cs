using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ProductCategories
{
    public class ProductCategoryQueryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}
