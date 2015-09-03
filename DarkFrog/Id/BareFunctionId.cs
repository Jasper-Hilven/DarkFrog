using System.Collections.Generic;

namespace DarkFrog.Id
{
  public abstract class BareFunctionId : IId
  {
    protected BareFunctionId()
    {
    }

    public IEnumerable<IId> GetProperties()
    {
      throw new System.NotImplementedException();
    }

    public IEnumerable<IId> GetPropertiesAndValues()
    {
      throw new System.NotImplementedException();
    }

    public bool ContainsProperty(IId property)
    {
      throw new System.NotImplementedException();
    }

    public IId GetProperty(IId property)
    {
      throw new System.NotImplementedException();
    }

    public void SetProperty(IId property, IId value)
    {
      throw new System.NotImplementedException();
    }

    public void RemoveProperty(IId property)
    {
      throw new System.NotImplementedException();
    }

    public bool IsRefIId()
    {
      return false;
    }

    public string GetStreamDescription()
    {
      throw new System.NotImplementedException();
    }

    public string GetFullPropertyDescription()
    {
      throw new System.NotImplementedException();
    }
  }
}