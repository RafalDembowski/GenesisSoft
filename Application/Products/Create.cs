using Application.General;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

namespace Application.Products
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public ProductCommandDto Product { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(p => p.Product).SetValidator(new ProductValidator());
            }
        }

        public class Handler : IRequestHandler<Command , Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            private readonly IUserAccessHelper _userAccessHelper;
            public Handler(DataContext context , IMapper mapper , IUserAccessHelper userAccessHelper)
            {
                _context = context;
                _mapper = mapper;
                _userAccessHelper = userAccessHelper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var product = _mapper.Map<Product>(request.Product);
                var userName = _userAccessHelper.GetCurrentUserName();

                product.CreatedBy = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
                product.Category = await _context.ProductCategories.FirstOrDefaultAsync(pc => pc.Id == request.Product.CategoryId);

                _context.Products.Add(product);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Problem creating a product.");

                return Result<Unit>.Success(Unit.Value);
            }
        }

    }
}
