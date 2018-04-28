using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShopProductSearch.Models
{
    public class ProductsSearchRequest
    {
        //Search
        public string Keyword { get; set; }
        //Paging
        public int? PageNumber { get; set; } = 0;
        public int? PageSize { get; set; } = 10;

        //Filters
        public string Category { get; set; }
        public string ProductID { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }

        //Sorting
        public string OrderBy { get; set; }
    }
}
