using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Helpers
{
    public static class SortHelpers
    {
        public static string ValidateSortQueryParameters(string sortQueryParameter)
        {
            StringBuilder sortQueryParameterBuilder = new StringBuilder();

            if (String.IsNullOrEmpty(sortQueryParameter))
                return "";

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
