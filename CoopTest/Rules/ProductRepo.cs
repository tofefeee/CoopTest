using CoopTest.Interfaces;
using CoopTest.Models;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CoopTest.Rules
{
  public class ProductRepo : IProductInterface
  {
    string _dbConnStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CoopText;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    
    public Task<string> AddProduct(Product product)
    {
      try
      {
        string query = "INSERT INTO Products VALUES(NEXT VALUE FOR dbo.Id, @Name, @EANCode);";

        using (SqlConnection dbConn = new SqlConnection(_dbConnStr))
        {
          using (SqlCommand command = new SqlCommand(query, dbConn))
          {
            dbConn.Open();
            command.Parameters.AddWithValue("@Name", product.Name);
            command.Parameters.AddWithValue("@EANCode", product.EANCode);
            command.ExecuteNonQuery();
          }
        }
        return Task.FromResult("Added");
      }
      catch (Exception ex)
      {
        return Task.FromResult(ex.Message);
      }
    }

    public Task<string> AddProductAssortment(ProductAssortment productAssortment)
    {
      try
      {
        string query = "INSERT INTO AssortmentProducts VALUES (@ProductId, @AssortmentId)";

        using (SqlConnection dbConn = new SqlConnection(_dbConnStr))
        {
          using (SqlCommand command = new SqlCommand(query, dbConn))
          {
            dbConn.Open();
            command.Parameters.AddWithValue("@ProductId", productAssortment.ProductId);
            command.Parameters.AddWithValue("@AssortmentId", productAssortment.AssortmentId);
            command.ExecuteNonQuery();
          }
        }
        return Task.FromResult("Added");
      }
      catch (Exception ex)
      {
        return Task.FromResult(ex.Message);
      }
    }
  }
}
