using CoopTest.Interfaces;
using CoopTest.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CoopTest.Rules
{
  public class AssortmentRepo : IAssortmentInterface
  {
    string _dbConnStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CoopText;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    
    public Task<string> AddAssortment(Assortment assortment)
    {
      try
      {
        string query = "INSERT INTO Assortments VALUES(NEXT VALUE FOR dbo.Id, @Name, @ActiveFrom, @ActiveTo);";

        using (SqlConnection connection = new SqlConnection(_dbConnStr))
        {
          using (SqlCommand command = new SqlCommand(query, connection))
          {
            connection.Open();
            command.Parameters.AddWithValue("@Name", assortment.Name);
            command.Parameters.AddWithValue("@ActiveFrom", assortment.ActiveFrom);
            command.Parameters.AddWithValue("@ActiveTo", assortment.ActiveTo);
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

    public List<Assortment> GetAssortments()
    {
      List<Assortment> result = new List<Assortment>();
      try
      {
        string query = "SELECT * FROM Assortments;";
        using (SqlConnection connection = new SqlConnection(_dbConnStr))
        {
          using (SqlCommand command = new SqlCommand(query, connection))
          {
            connection.Open();
            using (IDataReader reader = command.ExecuteReader())
            {
              while (reader.Read())
              {
                Assortment assortment = new Assortment();
                assortment.Name = reader.GetString(1);
                assortment.ActiveFrom = reader.GetDateTime(2);
                assortment.ActiveTo = reader.GetDateTime(3);

                result.Add(assortment);
              }
            }
          }
        }
        return result;
      }
      catch(Exception ex)
      {
        return null;
      }
    }
  }
}
