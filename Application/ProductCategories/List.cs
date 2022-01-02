using Application.General;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Infrastructure.Helpers;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ProductCategories
{
    public class List
    {
        public class Query : IRequest<Result<PagedList<ProductCategoryQueryDto>>>
        {
            public QueryParameters Params { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<PagedList<ProductCategoryQueryDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<PagedList<ProductCategoryQueryDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                string orderBy = SortHelper.ValidateSortQueryParameters(request.Params.OrderBy);

                var query = _context.ProductCategories
                    .OrderBy(orderBy)
                    .ProjectTo<ProductCategoryQueryDto>(_mapper.ConfigurationProvider)
                    .AsQueryable();

                return Result<PagedList<ProductCategoryQueryDto>>.Success(
                    await PagedList<ProductCategoryQueryDto>.ToPagedList(query, request.Params.PageNumber, request.Params.PageSize)
                );
            }
        }
    }
}
