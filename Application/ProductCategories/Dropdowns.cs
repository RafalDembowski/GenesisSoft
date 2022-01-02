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
    public class Dropdowns
    {
        public class Query : IRequest<Result<List<ProductCategoryDropdownItemDto>>>
        {

        }

        public class Handler : IRequestHandler<Query, Result<List<ProductCategoryDropdownItemDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<ProductCategoryDropdownItemDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var productCategory = await _context.ProductCategories.ProjectTo<ProductCategoryDropdownItemDto>(_mapper.ConfigurationProvider).ToListAsync();

                return Result<List<ProductCategoryDropdownItemDto>>.Success(productCategory);
            }
        }

    }
}
