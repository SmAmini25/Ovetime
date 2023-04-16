using Microsoft.EntityFrameworkCore;
using OvetimePolicies.Domain.Entity;
using OvetimePolicies.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OvetimePolicies.Application.Interface.Contexts
{
  internal interface IDBContextApplication : IBaseDbContext
  {
    DbSet<Person> People { get; set; }
  }
}
