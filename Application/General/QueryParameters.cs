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
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize || value < 0) ? MaxPageSize : value;
        }
        private string _orderBy;
        public string OrderBy 
        {
            get => _orderBy;
            set => _orderBy = value.ToLower();
        }
    }
}
