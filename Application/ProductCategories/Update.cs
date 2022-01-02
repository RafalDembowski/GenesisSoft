using Application.General;
using Application.Interfaces;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Application.ProductCategories
{

    public class Update
    {
        public class Command : IRequest<Result<Unit>>
        {
            public ProductCategoryCommandDto ProductCategory { get; set; }
            public Guid Id { get; set; }
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
                ProductCategory productCategory = await _context.ProductCategories.FindAsync(request.Id);

                if (productCategory == null) return null;

                _mapper.Map(request.ProductCategory, productCategory);

                var userName = _userAccessHelper.GetCurrentUserName();
                productCategory.UpdatedBy = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Problem updating product category.");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }

}
