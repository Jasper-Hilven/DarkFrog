using System;
using System.Collections.Generic;

namespace DarkFrog.Core.Id
{
  public class BoolId : IId
  {
    public static BoolId True = new BoolId(true);
    public static BoolId False = new BoolId(false);
    private bool value;

    private BoolId(bool value)
    {
      this.value = value;
    }
    // ReSharper disable once ParameterHidesMember
    public BoolId GetBoolId(bool value)
    {
      return value ? True : False;
    }

    public IEnumerable<IId> GetProperties()
    {
      return new List<IId>();
    }

    public IEnumerable<IId> GetPropertiesAndValues()
    {
      return new List<IId>();
    }

    public bool ContainsProperty(IId property)
    {
      return false;
    }

    public IId GetProperty(IId property)
    {
      throw new Exception();
    }

    public void SetProperty(IId property, IId value)
    {
      throw new Exception();
    }

    public void RemoveProperty(IId property)
    {
    }

    public bool IsRefIId()
    {
      return false;
    }

    public string GetStreamDescription()
    {
      return "B" + (value ? "T" : "F");
    }

    public string GetFullPropertyDescription()
    {
      return GetStreamDescription();
    }
  }
}