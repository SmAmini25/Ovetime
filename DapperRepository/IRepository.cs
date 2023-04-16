using Dapper;
using OvetimePolicies.Domain.Entity;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace DapperRepository
{
  public interface IRepository
  {
    List<Person> GetRange();
    Person? Get(int ID);
  }

  public class Repository : IRepository
  {
    //"WebApiContext": "Server=GOLDAMF;Database=WebApiContext;Trusted_Connection=True;MultipleActiveResultSets=true"

    //"DefaultConnection": "server=.;Database=Product;User ID=sa;Password=123456;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
    private readonly string ConnectionStrings = "server=.;Database=WebApiContext;User ID=sa;Password=123456;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

    public Repository() { }

    public List<Person> GetRange()
    {
      string sql = "SELECT * FROM People";
      var connection = new SqlConnection(ConnectionStrings);
      return connection.Query<Person>(sql).ToList();
    }

    public Person? Get(int ID)
    {
      string sql = "SELECT * FROM People where id=@id";
      var connection = new SqlConnection(ConnectionStrings);

      return connection.QueryFirstOrDefault<Person>(sql, new { id = ID });
    }
  }
}