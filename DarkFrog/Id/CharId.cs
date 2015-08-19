using System;
using System.Collections.Generic;

namespace DarkFrog.Id
{
  public class CharId:IId
  {
    private static Dictionary<char, CharId> StatConsts = new Dictionary<char, CharId>();

    public static CharId CreateCharId(char value)
    {
      CharId ret;
      if (StatConsts.TryGetValue(value, out ret))
        return ret;
      ret = new CharId();
      StatConsts.Add(value,ret);
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

  }
}