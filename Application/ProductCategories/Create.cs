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
namespace Application.ProductCategories
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public ProductCategoryCommandDto ProductCategory { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(p => p.ProductCategory).SetValidator(new ProductCategoryValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            private readonly IUserAccessHelper _userAccessHelper;
            public Handler(DataContext context, IMapper mapper, IUserAccessHelper userAccessHelper)
            {
                _context = context;
                _mapper = mapper;
                _userAccessHelper = userAccessHelper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var productCategory = _mapper.Map<ProductCategory>(request.ProductCategory);
                var userName = _userAccessHelper.GetCurrentUserName();
                productCategory.CreatedBy = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);

                _context.ProductCategories.Add(productCategory);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Problem creating a product category.");

                return Result<Unit>.Success(Unit.Value);
            }
        }

    }
}
