using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Helpers
{
    public static class SortHelper
    {
        public static string GetSortingType(string sortQueryParameter)
        {
            string[] splitedSortQueryParameter = sortQueryParameter.Split(" ");
            string sortingType = splitedSortQueryParameter.Length > 1 ? splitedSortQueryParameter[1] : "";
            return sortingType;
        }

        public static string ValidateSortQueryParameters(string sortQueryParameter)
        {
            StringBuilder sortQueryParameterBuilder = new StringBuilder();

            if (String.IsNullOrEmpty(sortQueryParameter))
                return "1";

            if (!(sortQueryParameter.EndsWith(" desc") ||  sortQueryParameter.EndsWith(" asc")))
            {
                sortQueryParameterBuilder.Append(sortQueryParameter.Split(" ")[0]);
                sortQueryParameterBuilder.Append(" desc");
                return sortQueryParameterBuilder.ToString();
            }

            return sortQueryParameter;

        }
    }
}
