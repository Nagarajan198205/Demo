using System;
using System.Collections.Generic;
using System.Linq;

namespace Boots.Models
{
    public class ProductRepository
    {
        private static List<Product> Products => new List<Product>
        {
            new Product {ProductId="10043827", ProductName="Paracetamol", ImageUrl = "10043827.jpg" },
            new Product {ProductId="10041265", ProductName="Paracetamol",  ImageUrl = "10041265.jpg" },
            new Product {ProductId="10149468", ProductName="Paracetamol", ImageUrl = "10149468.jpg" },
            new Product {ProductId="10008081", ProductName="Paracetamol", ImageUrl = "10008081.jpg" },
            new Product {ProductId="10032781", ProductName="Paracetamol", ImageUrl = "10032781.jpg" },
            new Product {ProductId="10067798", ProductName="Paracetamol", ImageUrl = "10067798.jpg" },
            new Product {ProductId="10032857", ProductName="Paracetamol", ImageUrl = "10032857.jpg" },
            new Product {ProductId="10084548", ProductName="Paracetamol", ImageUrl = "10084548.jpg" },
            new Product {ProductId="10186783", ProductName="Paracetamol", ImageUrl = "10186783.jpg" },
            new Product {ProductId="10191785", ProductName="Paracetamol", ImageUrl = "10191785.jpg" },
            new Product {ProductId="10067963", ProductName="Ibuprofen", ImageUrl = "10067963.jpg" },
            new Product {ProductId="10023682", ProductName="Ibuprofen", ImageUrl = "10023682.jpg" },
            new Product {ProductId="10067621", ProductName="Ibuprofen", ImageUrl = "10067621.jpg" },
            new Product {ProductId="10032828", ProductName="Ibuprofen", ImageUrl = "10032828.jpg" },
            new Product {ProductId="10016724", ProductName="Ibuprofen", ImageUrl = "10016724.jpg" },
            new Product {ProductId="10042859", ProductName="Ibuprofen", ImageUrl = "10042859.jpg" },
            new Product {ProductId="10067535", ProductName="Ibuprofen", ImageUrl = "10067535.jpg" },
            new Product {ProductId="10103591", ProductName="Ibuprofen", ImageUrl = "10103591.jpg" },
            new Product {ProductId="10131213", ProductName="Ibuprofen", ImageUrl = "10131213.jpg" },
            new Product {ProductId="10168107", ProductName="Ibuprofen", ImageUrl = "10168107.jpg" }
        };

        public static string ScanProduct(string productName)
        {
            return "Paracetamol";
        }

        public static List<Product> GetProducts(string productName)
        {
            return Products.Where(x => x.ProductName.Equals(productName, System.StringComparison.CurrentCultureIgnoreCase)).ToList();
        }
    }
}