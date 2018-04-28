using Microsoft.Azure.Search.Models;
using System.Collections.Generic;
using System.Text;

namespace MyShopProductSearch.Models
{
    public class ProductsSearchParameters : SearchParameters
    {
        public ProductsSearchParameters(ProductsSearchRequest request)
        { 
            QueryType = QueryType.Full;

            SearchFields = GetSearchFields(request);

            Filter = GetFilters(request);

            Facets = GetFacets();

            IncludeTotalResultCount = true;

            SetHighlightFields();

            SetSortingFields(request.OrderBy);

            Top = request.PageSize;
            Skip = (request.PageSize - 1) * request.PageNumber;
        }

        private List<string> GetSearchFields(ProductsSearchRequest request)
        {
            return new List<string>()
            {
                nameof(Document.Category),
                nameof(Document.Description),
                nameof(Document.ProductName),
                nameof(Document.ProductNumber)
            };
        }

        private string GetFilters(ProductsSearchRequest request)
        {
            var filters = new StringBuilder();

            if (!string.IsNullOrEmpty(request.ProductID))
            {
                filters.AppendFormat("ProductID eq '{0}'", request.ProductID);
            }

            if (!string.IsNullOrEmpty(request.Color))
            {
                if (filters.Length > 0) filters.Append(" and ");

                filters.AppendFormat("search.in(Color, '{0}')", request.Color);
            }

            if (!string.IsNullOrEmpty(request.Size))
            {
                if (filters.Length > 0) filters.Append(" and ");

                filters.AppendFormat("Size eq '{0}'", request.Size);
            }

            if (!string.IsNullOrEmpty(request.Category))
            {
                if (filters.Length > 0) filters.Append(" and ");

                filters.AppendFormat("Category eq '{0}'", request.Category);
            }

            return filters.ToString();
        }

        private List<string> GetFacets()
        {
            return new List<string>()
            {
                  nameof(Document.Category),
                  nameof(Document.Color),
                  nameof(Document.Size)
            };
        }

        private void SetHighlightFields()
        {
            HighlightPreTag = "<b>";
            HighlightPostTag = "</b>";

            HighlightFields = new List<string>
            {
                nameof(Document.Description)
            };
        }

        private void SetSortingFields(string orderBy)
        {
            if (string.IsNullOrEmpty(orderBy))
            {
                ScoringProfile = "DefaultRelevancy";
            }
            else
            {
                OrderBy = new List<string> { $"{orderBy}" };
            }
        }
    }
}
