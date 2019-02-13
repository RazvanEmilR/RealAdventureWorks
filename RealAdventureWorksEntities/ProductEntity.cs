using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWCFServices.RealAdventureWorksEntities
{
    public class ProductEntity
    {
        public int ProductID { get; set; }
        public string Color { get; set; }
        public decimal ListPrice { get; set; }

        public DateTime DiscontinuedDate { get; set; }


        // used internally
        public int UnitsInStock { get; set; }
        
        public int UnitsOnOrder { get; set; }

        public int ReorderLevel { get; set; }
    }
}
