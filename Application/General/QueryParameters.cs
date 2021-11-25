using System;
using System.Collections.Generic;
using System.Text;

namespace Application.General
{
    public class QueryParameters
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > MaxPageSize || value < 0 ) ? MaxPageSize : value;
            }
        }
        public string OrderBy { get; set; }
    }
}
