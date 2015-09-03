using System;
using System.Collections.Generic;

namespace DarkFrog.Id
{
  public class IntId : IId
  {
    private static IntId zero = new IntId(0);
    private static IntId one = new IntId(1);
    public int Value { get; private set; }


    private IntId(int value)
    {
      this.Value = value;
    }

    public static IntId CreateId(int number)
    {
      if (number == 0) 
        return zero;
      if (number == 1) 
      return one;
      return new IntId(number);
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
      throw new SystemException();
    }

    public void SetProperty(IId property, IId value)
    {
      throw new SystemException();
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
      return "I" + value;
    }

    public string GetFullPropertyDescription()
    {
      return GetStreamDescription();
    }
  }
}