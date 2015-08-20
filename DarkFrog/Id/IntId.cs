using System;
using System.Collections.Generic;

namespace DarkFrog.Id
{
  public class IntId : IId
  {
    private static IntId zero = new IntId(0);
    private static IntId one = new IntId(1);
    private int value;


    private IntId(int value)
    {
      this.value = value;
    }

    public static IntId CreateId(int number)
    {
      if (number == 0) 
        return zero;
      if (number == 1) 
      return one;
      return new IntId(number);
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