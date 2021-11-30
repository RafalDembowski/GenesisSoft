using Application.General;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    public class Details
    {
        public class Query : IRequest<Result<ProductQueryDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<ProductQueryDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<ProductQueryDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.ProjectTo<ProductQueryDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(p => p.Id == request.Id);

                return Result<ProductQueryDto>.Success(product);
            }

        }
    }
}
