using Microsoft.AspNetCore.Mvc;
using DapperRepository;
using Microsoft.Data.SqlClient;
using Dapper;
using OvetimePolicies.Domain.Entity;
using OvetimePolicies.Application.Services.People.FacadPattern;
using Microsoft.AspNetCore.Http.HttpResults;
using OvetimePolicies.Application.Services.People.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
  //[Route("api/[controller]")]
  [Route("api/{datatype}/[controller]")]
  [ApiController]
  public class CalcurlatorController : ControllerBase
  {
    private readonly IFacadPerson Person;

    public CalcurlatorController(IFacadPerson person)
    {
      Person = person;
    }


    [HttpGet]
    public IActionResult Get(string? datatype)
    {
      var list = Person.GetListPerson.Execute();
      if (list != null && list.OK)
      {
        return Ok(list);
      }

      return new NotFoundResult();
    }

    // GET api/<PersonController>/5
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
      var result = Person.GetPerson.Execute(id);
      if (result != null && result.OK)
      {
        return Ok(result);
      }

      return new NotFoundResult();
    }

    // POST api/<PersonController>
    [HttpPost]
    public IActionResult Post(string? datatype, [FromBody] PersonDto request)
    {
      if (ModelState.IsValid)
      {
        var result = Person.CreatePerson.Execute(request);
        if (result != null && result.OK)
        {
          return Ok(result);
        }
      }

      return new NotFoundResult();
    }

    // PUT api/<PersonController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<PersonController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }

  public class RequestCalcurlator
  {
    public string? Data { get; set; }

    public string? OverTimeCalculator { get; set; }
  }

}
