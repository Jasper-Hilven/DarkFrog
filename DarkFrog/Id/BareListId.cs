using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkFrog.Id
{
  class BareListId:IId
  {
    public IEnumerable<IId> GetProperties()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<IId> GetPropertiesAndValues()
    {
      throw new NotImplementedException();
    }

    public bool ContainsProperty(IId property)
    {
      throw new NotImplementedException();
    }

    public IId GetProperty(IId property)
    {
      throw new NotImplementedException();
    }

    public void SetProperty(IId property, IId value)
    {
      throw new NotImplementedException();
    }

    public void RemoveProperty(IId property)
    {
      throw new NotImplementedException();
    }

    public bool IsRefIId()
    {
      throw new NotImplementedException();
    }

    public string GetStreamDescription()
    {
      throw new NotImplementedException();
    }

    public string GetFullPropertyDescription()
    {
      throw new NotImplementedException();
    }
  }
}
