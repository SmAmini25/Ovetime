using Microsoft.EntityFrameworkCore;
using OvetimePolicies.Application.Interface.Contexts;
using OvetimePolicies.Domain.Entity;

namespace OvetimePolicies.Persistence.Data
{
  public class DataBaseContext : DbContext, IDBContextApplication
  {
    public DataBaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Person> People { get; set; } = default!;
  }
}