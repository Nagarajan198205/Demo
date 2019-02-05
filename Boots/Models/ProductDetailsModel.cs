using System.Collections.Generic;

namespace Boots.Models
{
    public class ProductDetailsModel
    {
        public ProductModel ProductModel { get; set; }

        public IEnumerable<Product> ProductList { get; set; } = new List<Product>();
    }
}