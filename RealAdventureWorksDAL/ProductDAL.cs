using MyWCFServices.RealAdventureWorksEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace MyWCFServices.RealAdventureWorksDAL
{
    public class ProductDAL
    {
        readonly string connectionString = ConfigurationManager.AppSettings["AdventureWorksLTConnectionString"];


        public ProductEntity GetProduct (int id)
        {
            // TODO: connect to DB to retrieve product

            /*
            ProductEntity p = new ProductEntity();

            p.ProductID = id;
            p.Color = "fake Color from data access layer";
            p.ListPrice = (decimal)30.00;

            if (id > 50) p.UnitsOnOrder = 30;

            return p;
            */

            ProductEntity p = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "select * from SalesLT.Product where ProductID=" + id;
                comm.Connection = conn;
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                if(reader.HasRows)
                {
                    reader.Read();
                    p = new ProductEntity();
                    p.ProductID = id;

                    p.Color = (string)reader["Color"];
                    p.ListPrice = (decimal)reader["ListPrice"];
                    p.DiscontinuedDate = reader["DiscontinuedDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["DiscontinuedDate"].ToString());


                    // using a different database without these field so hardcoding these values
                    p.UnitsInStock = 1;
                    p.UnitsOnOrder = 1;
                    p.ReorderLevel = 1;
                }
            }
            return p;
        }

        public bool UpdateProduct (ProductEntity product)
        {
            //TODO: connect to DB to update product
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                int numRows = 0;
                SqlCommand cmd = new SqlCommand("UPDATE SalesLT.Product SET " +
                                                "Color=@color,ListPrice=@listPrice " +
                                                "WHERE ProductID=@id");

                cmd.Parameters.AddWithValue("@color", product.Color);
                cmd.Parameters.AddWithValue("@listPrice", product.ListPrice);
                cmd.Parameters.AddWithValue("@id", product.ProductID);

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    numRows = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
                if (numRows != 1)
                    return false;
            }

            return true;
        }
    }
}
