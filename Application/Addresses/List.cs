using Application.General;
using Domain;
using Infrastructure.Helpers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Addresses
{
    public class List
    {
        public class Query : IRequest<Result<PagedList<Address>>> 
        { 
            public QueryParameters Params { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<PagedList<Address>>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<PagedList<Address>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var orderBy = SortHelpers.ValidateSortQueryParameters(request.Params.OrderBy);

                var query = _context.Addresses
                    .OrderBy(orderBy)
                    .AsQueryable();
                
                return Result<PagedList<Address>>.Success( 
                    await PagedList<Address>.ToPagedList(query , request.Params.PageNumber , request.Params.PageSize )
                );
            }
        }
    }
}
