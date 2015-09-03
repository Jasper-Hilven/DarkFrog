using System;
using System.Collections.Generic;
using System.Text;

namespace DarkFrog.Id
{
  public class BareListId:IId
  {
    private static long stID = 0;
    private long id;

    private BareListId()
    {
      id = stID++;
    }

    private List<IId> list = new List<IId>(); 
    public IEnumerable<IId> GetProperties()
    {

      for (int i = 0; i < list.Count; i++)
      {
        yield return IntId.CreateId(i);
      }
      
    }

    public IEnumerable<IId> GetPropertiesAndValues()
    {
      foreach (var property in GetProperties())
      {
        yield return property;
      }
      foreach (var id1 in list)
      {
        yield return id1;
      }
    }

    public bool ContainsProperty(IId property)
    {
      if(!(property is IntId))
        return false;
      int pVal = ((IntId )property).Value;
      return pVal >= 0 && pVal < list.Count;
    }

    public IId GetProperty(IId property)
    {
      if(!ContainsProperty(property))
        throw new Exception();
      int pVal = ((IntId)property).Value;
      return list[pVal];
    }

    public void SetProperty(IId property, IId value)
    {
      if (!(property is IntId))
        throw new Exception();
      int pVal = ((IntId)property).Value;
      if(!( pVal >= 0 && pVal <= list.Count))
        throw new Exception();
      list[pVal] = value;
      throw new NotImplementedException();
    }

    public void RemoveProperty(IId property)
    {
      if (!ContainsProperty(property))
        throw new Exception();
      int pVal = ((IntId)property).Value;
      list.RemoveAt(pVal);
    }

    public bool IsRefIId()
    {
      return false;
    }

    public string GetStreamDescription()
    {
      return "L" + id + " ";
    }

    public string GetFullPropertyDescription()
    {
      var ret = new StringBuilder(GetStreamDescription());
      foreach (var kp in list)
        ret.Append(kp.GetStreamDescription());
      return ret.ToString();
    }
  }
}
