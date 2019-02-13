using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWCFServices.RealAdventureWorksDAL;
using MyWCFServices.RealAdventureWorksEntities;

namespace MyWCFServices.RealAdventureWorksLogic
{
    public class ProductLogic
    {
        // productDAL will access the actual database from the Data Access Layer
        ProductDAL productDAL = new ProductDAL();
        public ProductEntity GetProduct(int id)
        {
            return productDAL.GetProduct(id);
            /*
            ProductEntity p = new ProductEntity();

            p.ProductID = id;
            p.Color = "fake product color from business logic layer";

            if (id > 50) p.UnitsOnOrder = 30;

            return p;
            */
        }

        public bool UpdateProduct(ProductEntity product)
        {
            // TODO: call data access layer to update product

            // first check to see if it is a valid price
            if (product.ListPrice <= 0)
                return false;
            // Color can't be empty
            else if (product.Color == null || product.Color.Length == 0)
                return false;
     
            // then validate other properties
            else
            {
                ProductEntity productInDB = GetProduct(product.ProductID);
                // invalid product to update
                if (productInDB == null)
                    return false;
                // a product can't be discontinued if there are non-fulfilled orders
                else if (product.DiscontinuedDate == null && productInDB.UnitsOnOrder > 0)
                    return false;
                else
                    // return true;
                    return productDAL.UpdateProduct(product);
            }
        }
    }
}
