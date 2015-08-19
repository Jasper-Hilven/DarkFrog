using System;
using System.Collections.Generic;

namespace DarkFrog.Id
{
  public class IntId : IId
  {
    public static Dictionary<int, IntId> StatConsts = new Dictionary<int, IntId>();
    
    private IntId()
    {
    }

    public static IntId CreateId(int number)
    {
      IntId ret;
      if (StatConsts.TryGetValue(number, out ret))
        return ret;
      ret = new IntId();
      StatConsts.Add(number,ret);
      return ret;
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

    public bool IsRefIId()
    {
      return false;
    }
  }
}