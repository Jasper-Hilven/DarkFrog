using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DarkFrog.Id;
using DarkFrog.Namespacing;

namespace DarkFrog.Collections
{
  class DfSet:IPersistencyNameContainer
  {
    private static readonly IId setId = new RefId(); public static IId SetId() { return setId; }
    private static readonly IId setProperty = new RefId(); public static IId SetProperty() { return setProperty; }

    public Dictionary<string, IId> GetIIds()
    {
      return new Dictionary<string, IId>(){{"DfSetId",setId},{"DfSetProperty", setProperty} };
    }

    public static IId CreateSet()
    {
      return CreateSet(new HashSet<IId>());
    }

    public static IId CreateSet(ISet<IId> values)
    {
      var set = new RefId();
      var rawSet = new RefId();
      set.SetProperty(setId,rawSet);
      foreach (var value in values)
        set.SetProperty(value,setProperty);
      return set;
    }

    public static bool IsSet(IId id)
    {
      return id.ContainsProperty(setId);
    }

    public static void AddToSet(IId set,IId value)
    {
      var rawId = set.GetProperty(setId);
      rawId.SetProperty(setProperty,value);
    }

    public string GetPrefix()
    {
      return "DfSet";
    }
  }
}
