using Application.General;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
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
                var query = _context.Addresses.AsQueryable();
                return Result<PagedList<Address>>.Success( 
                    await PagedList<Address>.ToPagedList(query , request.Params.PageNumber , request.Params.PageSize )
                );
            }
        }
    }
}
