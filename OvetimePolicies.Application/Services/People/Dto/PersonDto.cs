using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OvetimePolicies.Application.Services.People.Dto
{
  public class PersonDto
  {
    public int ID { get; set; }
    [MaxLength(50)]
    public string? FirstName { get; set; }

    public decimal BasicSalary { get; set; }

    public decimal Allowance { get; set; }

    public decimal Transportation { get; set; }

    public decimal CalcurlatorTax { get; set; }
  }
}
