using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DarkFrog.Core.Id
{
  class BareSetId:IId
  {
    private static long stID = 0;
    private long id;

    private BareSetId()
    {
      this.id = stID++;
    }

    public static BareSetId CreateBareSetId()
    {
      return new BareSetId();
    }

    private HashSet<IId> set = new HashSet<IId>(); 
    public IEnumerable<IId> GetProperties()
    {
      return set.ToList();
    }

    public IEnumerable<IId> GetPropertiesAndValues()
    {
      return set.ToList();
    }

    public bool ContainsProperty(IId property)
    {
      return set.Contains(property);
    }

    public IId GetProperty(IId property)
    {
      if(!set.Contains(property))
        throw new Exception();
      return property;
    }

    public void SetProperty(IId property, IId value)
    {
      set.Add(property);
    }

    public void RemoveProperty(IId property)
    {
      set.Remove(property);
    }

    public bool IsRefIId()
    {
      return false;
    }

    public string GetStreamDescription()
    {
      return "BS" + id + " ";
    }

    public string GetFullPropertyDescription()
    {
      var ret = new StringBuilder(GetStreamDescription());
      foreach (var kp in set)
        ret.Append(kp.GetStreamDescription());
      return ret.ToString();
    }
  }
}
