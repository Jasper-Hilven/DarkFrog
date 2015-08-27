using System;
using System.Collections.Generic;
using System.Linq;

namespace DarkFrog.Id
{
  public class StringId:IId
  {
    protected bool Equals(StringId other)
    {
      return string.Equals(value, other.value);
    }

    public override int GetHashCode()
    {
      return (value != null ? value.GetHashCode() : 0);
    }

    private readonly string value;

    public StringId(string value)
    {
      this.value = value;
    }

    public static StringId CreateStringId(string value)
    {
      var ret = new StringId(value);
      return ret;
    }

    public IEnumerable<IId> GetProperties()
    {
      throw new Exception();
    }

    public IEnumerable<IId> GetPropertiesAndValues()
    {
      throw new Exception();
    }

    public bool ContainsProperty(IId property)
    {
      return false;
    }

    public IId GetProperty(IId property)
    {
      throw new System.Exception();
    }

    public void SetProperty(IId property, IId value)
    {
      throw new System.Exception();
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
      return "S" + string.Join("", value.Select(c => ((int)c).ToString("X2")));
    }

    public string GetFullPropertyDescription()
    {
      return GetStreamDescription();
    }

    public override bool Equals(object obj)
    {
      var other = obj as StringId;
      if (other == null)
        return false;
      return other.value == value;
    }
  }
}