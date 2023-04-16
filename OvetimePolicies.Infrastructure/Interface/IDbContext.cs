using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OvetimePolicies.Infrastructure.Interface
{
  public interface IBaseDbContext
  {
    int SaveChanges(bool acceptAllChangesOnSuccess);
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
  }

  public class ResultDto<T>
    where T : class, new()
  {
    public T Data { get; set; }

    public bool OK { get; set; }
  }
}
