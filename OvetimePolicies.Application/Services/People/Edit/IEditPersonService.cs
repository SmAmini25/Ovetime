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
  public interface IEditPersonService
  {
    ResultDto<PersonDto> Execute(PersonDto personDto);
  }

  public class EditPersonService : IEditPersonService
  {
    private readonly IDBContextApplication DB;

    public EditPersonService(IDBContextApplication dB)
    {
      DB = dB;
    }

    public ResultDto<PersonDto> Execute(PersonDto personDto)
    {
      ResultDto<PersonDto> result = new();

      result.Data = personDto;

      Person? person = DB.People.FirstOrDefault(x => x.ID == personDto.ID);
      if (person == null)
      {
        // کلاس ResultDto باید مشخصه ای برای برگشت نوع خطا هم باشد که اینجا پیدا نکردن موجودی می باشد
        result.OK = false;
      }
      else
      {
        // این قسمت باید از Mapper استفاده بشود به دلیل زمان صرف نظر کردم.
        person.Transportation = personDto.Transportation;
        person.BasicSalary = personDto.BasicSalary;
        person.CalcurlatorTax = personDto.CalcurlatorTax;
        person.Allowance = personDto.Allowance;
        person.FirstName = personDto.FirstName;

        DB.SaveChanges();
        result.OK = true;
      }

      return result;
    }
  }


}
