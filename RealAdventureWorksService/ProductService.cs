using MyWCFServices.RealAdventureWorksEntities;
using MyWCFServices.RealAdventureWorksLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyWCFServices.RealAdventureWorksService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ProductService : IProductService
    {
        ProductLogic productLogic = new ProductLogic();
        public Product GetProduct(int id)
        {
            ProductEntity productEntity = productLogic.GetProduct(id);

            if (productEntity == null)
            {
                throw new Exception("No product found with id " + id);
                /*
                if (id != 999)
                {    
                }
                */
            }

            Product product = new Product();

            TranslateProductEntityToProductContractData(productEntity, product);

            return product;
            /*
            Product product = new Product();
            product.ProductID = id;
            product.Color = "fake color from service layer";
            product.ListPrice = (decimal)10.0;
            return product;
            */
        }

        public bool UpdateProduct(Product product)
        {
            ProductEntity productEntity = new ProductEntity();

            TranslateProductContractDataToProductEntity(product, productEntity);

            return productLogic.UpdateProduct(productEntity);

            /*
            if (product.ListPrice <= 0)
                return false;
            else
                return true;
            */
        }

        private void TranslateProductEntityToProductContractData(
            ProductEntity productEntity, Product product)
        {
            product.ProductID = productEntity.ProductID;
            product.Color = productEntity.Color;
            product.ListPrice = productEntity.ListPrice;
        }

        private void TranslateProductContractDataToProductEntity(
            Product product, ProductEntity productEntity)
        {
            productEntity.ProductID = product.ProductID;
            productEntity.Color = product.Color;
            productEntity.ListPrice = product.ListPrice;
        }
    }
}
