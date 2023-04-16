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
  public interface ICreatePersonService
  {
    ResultDto<PersonDto> Execute(PersonDto personDto);
  }

  public class CreatePersonService : ICreatePersonService
  {
    private readonly IDBContextApplication DB;

    public CreatePersonService(IDBContextApplication dB)
    {
      DB = dB;
    }

    public ResultDto<PersonDto> Execute(PersonDto personDto)
    {
      ResultDto<PersonDto> result = new();

      result.Data = personDto;
      Person person = new();
      // این قسمت باید از Mapper استفاده بشود به دلیل زمان صرف نظر کردم.
      person.Transportation = personDto.Transportation;
      person.BasicSalary = personDto.BasicSalary;
      person.CalcurlatorTax = personDto.CalcurlatorTax;
      person.Allowance = personDto.Allowance;
      person.FirstName = personDto.FirstName;

      DB.People.Add(person);
      DB.SaveChanges();
      result.OK = true;

      return result;
    }
  }


}
