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
        public class Query : IRequest<Result<PagedList<ProductListDto>>>
        {
            public QueryParameters Params { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<PagedList<ProductListDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context , IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<PagedList<ProductListDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                string orderBy = SortHelper.ValidateSortQueryParameters(request.Params.OrderBy);

                var query = _context.Products
                    .OrderBy(orderBy)
                    .ProjectTo<ProductListDto>(_mapper.ConfigurationProvider)
                    .AsQueryable();

                return Result<PagedList<ProductListDto>>.Success(
                    await PagedList<ProductListDto>.ToPagedList(query, request.Params.PageNumber, request.Params.PageSize)
                );
            }
        }
    }
}
