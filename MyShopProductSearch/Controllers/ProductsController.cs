using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using MyShopProductSearch.Models;
using MyShopProductSearch.Utilities;

namespace MyShopProductSearch.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        SearchServiceClient _serviceClient;
        SearchIndexClient _indexClient;

        public ProductsController()
        {
            string searchServiceName = Configuration.Get("Search:ServiceName");
            string searchServiceApiKey = Configuration.Get("Search:ServiceAdminApiKey");
            string indexName = Configuration.Get("Search:IndexName");

            _serviceClient = new SearchServiceClient(searchServiceName, new SearchCredentials(searchServiceApiKey));
            _indexClient = new SearchIndexClient(searchServiceName, indexName, new SearchCredentials(searchServiceApiKey));
        }

        // GET: api/Products
        [HttpGet]
        public async Task<DocumentSearchResult> Get(ProductsSearchRequest request)
        {
            var parameters = new ProductsSearchParameters(request);
            request.Keyword = GetFuzzyString(request.Keyword);

            var results = await _indexClient.Documents.SearchAsync(request.Keyword, parameters);

            return  results;
        }

        // GET: api/Products
        [HttpGet]
        [Route("api/Products/Suggestions")]
        public async Task<DocumentSuggestResult> Suggest(string searchText)
        {
            var results = await _indexClient.Documents.SuggestAsync(searchText, "ProductSuggester");

            return results;
        }

        private string GetFuzzyString(string searchTerm)
        {
            return $"{searchTerm}~2 || {searchTerm}*";           
        }

    }

}
