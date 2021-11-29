using Application.General;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Products
{
    public class Update
    {
        public class Command : IRequest<Result<Unit>>
        {
            public ProductCreateDto Product { get; set; }
            public Guid Id { get; set; }
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

            public async Task<Result<Unit>> Handle(Command request , CancellationToken cancellationToken)
            {
                Product product = await _context.Products.FindAsync(request.Id);

                if (product == null) return null;

                _mapper.Map(request.Product , product);

                var userName = _userAccessHelper.GetCurrentUserName();
                product.UpdatedBy = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Problem updating product.");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
