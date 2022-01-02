using Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Products
{
    public class ProductValidator : AbstractValidator<ProductCommandDto>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.CategoryId).NotEmpty();
            RuleFor(p => p.ProducerId).NotEmpty();
        }
    }
}
