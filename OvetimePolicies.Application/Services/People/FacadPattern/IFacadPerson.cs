using OvetimePolicies.Application.Services.People.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OvetimePolicies.Application.Services.People.FacadPattern
{
  public interface IFacadPerson
  {
    ICreatePersonService CreatePerson { get; set; }
    IEditPersonService EditPerson { get; set; }
    IGetPersonService GetPerson { get; set; }
    IGetListPersonService GetListPerson { get; set; }
  }

  public class FacadPerson : IFacadPerson
  {

    public FacadPerson(
         ICreatePersonService createPerson,
         IEditPersonService editPerson,
         IGetPersonService getPerson,
         IGetListPersonService getListPerson)
    {
      CreatePerson = createPerson;
      EditPerson = editPerson;
      GetPerson = getPerson;
      GetListPerson = getListPerson;
    }
    public ICreatePersonService CreatePerson { get; set; }
    public IEditPersonService EditPerson { get; set; }
    public IGetPersonService GetPerson { get; set; }
    public IGetListPersonService GetListPerson { get; set; }
  }
}
