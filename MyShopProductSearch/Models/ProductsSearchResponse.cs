namespace MyShopProductSearch.Models
{

    public class ProductSearchResult
    {
        public int count { get; set; }
        public object coverage { get; set; }
        public Facets facets { get; set; }
        public Result[] results { get; set; }
        public object continuationToken { get; set; }
    }

    public class Facets
    {
        public Category[] Category { get; set; }
        public Color[] Color { get; set; }
    }

    public class Category
    {
        public int type { get; set; }
        public object from { get; set; }
        public object to { get; set; }
        public string value { get; set; }
        public int count { get; set; }
    }

    public class Color
    {
        public int type { get; set; }
        public object from { get; set; }
        public object to { get; set; }
        public string value { get; set; }
        public int count { get; set; }
    }

    public class Result
    {
        public float score { get; set; }
        public object highlights { get; set; }
        public Document document { get; set; }
    }

    public class Document
    {
        public string ModelName { get; set; }
        public string Description { get; set; }
        public string ProductName { get; set; }
        public string ProductID { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public string Color { get; set; }
        public string StandardCost { get; set; }
        public string ListPrice { get; set; }
        public string Size { get; set; }
        public object Weight { get; set; }
        public int ProductCategoryID { get; set; }
        public int ProductModelID { get; set; }
        public string ThumbnailPhotoFileName { get; set; }
        public string Category { get; set; }
    }

}