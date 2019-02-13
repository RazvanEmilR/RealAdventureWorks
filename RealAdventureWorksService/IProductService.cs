using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyWCFServices.RealAdventureWorksService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        Product GetProduct(int value);

        [OperationContract]
        bool UpdateProduct(Product product);

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "RealAdventureWorksService.ContractType".
    [DataContract]
    public class Product
    {
        [DataMember]
        public int ProductID { get; set; }
              
        [DataMember]
        public string Color { get; set; }
      
        [DataMember]
        public decimal ListPrice { get; set; }  
    }
}
