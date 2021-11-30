using Application.General;
using Domain;
using Infrastructure.Helpers;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Application.Products
{
    public class List
    {
        public class Query : IRequest<Result<PagedList<ProductQueryDto>>>
        {
            public QueryParameters Params { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<PagedList<ProductQueryDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context , IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<PagedList<ProductQueryDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                string orderBy = SortHelper.ValidateSortQueryParameters(request.Params.OrderBy);

                var query = _context.Products
                    .OrderBy(orderBy)
                    .ProjectTo<ProductQueryDto>(_mapper.ConfigurationProvider)
                    .AsQueryable();

                return Result<PagedList<ProductQueryDto>>.Success(
                    await PagedList<ProductQueryDto>.ToPagedList(query, request.Params.PageNumber, request.Params.PageSize)
                );
            }
        }
    }
}
