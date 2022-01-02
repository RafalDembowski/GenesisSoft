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

namespace Application.ProductCategories
{
    public class Details
    {
        public class Query : IRequest<Result<ProductCategoryQueryDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<ProductCategoryQueryDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<ProductCategoryQueryDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var productCategory = await _context.ProductCategories.ProjectTo<ProductCategoryQueryDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(p => p.Id == request.Id);

                return Result<ProductCategoryQueryDto>.Success(productCategory);
            }
        }
    }
}
