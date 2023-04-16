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
  public interface IGetListPersonService
  {
    ResultDto<List<PersonDto>> Execute();
  }

  public class GetListPersonService : IGetListPersonService
  {
    //private readonly IDBContextApplication DB;
    private readonly IRepository DB;

    public GetListPersonService(IRepository dB)
    {
      DB = dB;
    }

    public ResultDto<List<PersonDto>> Execute()
    {
      ResultDto<List<PersonDto>> result = new();

      result.OK = false;

      var people = DB.GetRange();
      if (people == null && people.Count > 0)
      {
        foreach (var person in people)
        {
          var dto = new PersonDto();

          // این قسمت باید از Mapper استفاده بشود به دلیل زمان صرف نظر کردم.
          dto.Transportation = person.Transportation;
          dto.BasicSalary = person.BasicSalary;
          dto.CalcurlatorTax = person.CalcurlatorTax;
          dto.Allowance = person.Allowance;
          dto.FirstName = person.FirstName;
          result.Data.Add(dto);
        }


        result.OK = true;
      }

      return result;
    }
  }


}
