using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealAdventureWorksClient.ProductServiceRef;

namespace RealAdventureWorksClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductServiceClient client = new ProductServiceClient();

            Product product = client.GetProduct(23);

            Console.WriteLine("Product color is: " + product.Color);
            Console.WriteLine("Product list price is: " + product.ListPrice);

            product.ListPrice = (decimal)20.0;

            bool result = client.UpdateProduct(product);

            Console.WriteLine("Update result is: " + result.ToString());
            Console.ReadLine();
         }
    }
}
