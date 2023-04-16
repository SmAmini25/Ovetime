using DapperRepository;
using OvetimePolicies.Application.Interface.Contexts;
using OvetimePolicies.Application.Services.People.Dto;
using OvetimePolicies.Domain.Entity;
using OvetimePolicies.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OvetimePolicies.Application.Services.People.Create
{
  public interface IGetPersonService
  {
    ResultDto<PersonDto> Execute(int? ID);
  }

  public class GetPersonService : IGetPersonService
  {
    //private readonly IDBContextApplication DB;
    private readonly IRepository DB;

    public GetPersonService(IRepository dB)
    {
      DB = dB;
    }

    public ResultDto<PersonDto> Execute(int? ID)
    {
      ResultDto<PersonDto> result = new();

      result.OK = false;
      if (ID != null)
      {
        var person = DB.Get(ID.Value);
        if (person == null)
        {
          // این قسمت باید از Mapper استفاده بشود به دلیل زمان صرف نظر کردم.
          result.Data.Transportation = person.Transportation;
          result.Data.BasicSalary = person.BasicSalary;
          result.Data.CalcurlatorTax = person.CalcurlatorTax;
          result.Data.Allowance = person.Allowance;
          result.Data.FirstName = person.FirstName;

          result.OK = true;
        }
      }

      return result;
    }
  }


}
