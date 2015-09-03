using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkFrog.Id
{
  class BareSetId:IId
  {
    private static long stID = 0;
    private long id;

    private BareSetId()
    {
      this.id = stID++;
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
