using System;
using System.Collections.Generic;

namespace DarkFrog.Id
{
  public class StringId:IId
  {
    private readonly string value;

    private StringId(string value)
    {
      this.value = value;
    }

    public static StringId CreateStringId(string value)
    {
      var ret = new StringId(value);
      return ret;
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

    public bool IsRefIId()
    {
      return false;
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