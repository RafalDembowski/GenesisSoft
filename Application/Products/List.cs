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

namespace Application.Products
{
    public class List
    {
        public class Query : IRequest<Result<PagedList<Product>>>
        {
            public QueryParameters Params { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<PagedList<Product>>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<PagedList<Product>>> Handle(Query request, CancellationToken cancellationToken)
            {
                string orderBy = SortHelpers.ValidateSortQueryParameters(request.Params.OrderBy);

                var query = _context.Products
                    .OrderBy(orderBy)
                    .AsQueryable();

                return Result<PagedList<Product>>.Success(
                    await PagedList<Product>.ToPagedList(query, request.Params.PageNumber, request.Params.PageSize)
                );
            }
        }
    }
}
