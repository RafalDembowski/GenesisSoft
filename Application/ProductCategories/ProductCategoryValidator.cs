using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ProductCategories
{
    public class ProductCategoryValidator : AbstractValidator<ProductCategoryCommandDto>
    {
        public ProductCategoryValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
        }
    }
}
