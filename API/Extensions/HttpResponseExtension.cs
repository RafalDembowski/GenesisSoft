using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Extensions
{
    public static class HttpResponseExtension
    {
        public static void AddParametersPaginationHeader(this HttpResponse response , int currentPage , int pageSize , int totalCount , int totalPages )
        {
            var parametersPaginationHeader = new
            {
                currentPage,
                pageSize,
                totalCount,
                totalPages
            };
            response.Headers.Add("Pagination", JsonSerializer.Serialize(parametersPaginationHeader));
        }

    }
}
