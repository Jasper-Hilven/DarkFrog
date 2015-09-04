using System;
using System.Collections.Generic;
using DarkFrog.Id;
using DarkFrog.Namespacing;
using DarkFrog.Persistency;

namespace DarkFrog.Collections
{
  class DfSet:IPersistencyNameContainer ,INameSpaceContainer
  {
    private static readonly IId setId = Naming.GetNamedId("setId"); public static IId SetId() { return setId; }
    private static readonly IId setNs = Naming.GetNamedId("setNs"); public static IId SetNs() { return setNs; }

    public Dictionary<string, IId> GetPersistencyNamesFromIds()
    {
      return new Dictionary<string, IId>(){{"DfSetId",setId},{"setNs", setNs} };
    }

    public static IId CreateSet()
    {
      return CreateSet(new HashSet<IId>());
    }

    public static IId CreateSet(ISet<IId> values)
    {
      var set = RefId.CreateRefId();
      var rawSet = BareSetId.CreateBareSetId();
      set.SetProperty(setId,rawSet);
      foreach (var value in values)
        set.SetProperty(value, value);
      return set;
    }

    public static bool IsSet(IId id)
    {
      return id.ContainsProperty(setId);
    }

    public static void AddToSet(IId set,IId value)
    {
      var rawId = set.GetProperty(setId);
      rawId.SetProperty(value,value);
    }

    public string GetPrefix()
    {
      return "DfSet";
    }

    public IEnumerable<Tuple<IId, IId>> GetHierarchy(NameSpaceBuilder builder)
    {
      yield return new Tuple<IId, IId>(builder.GetRoot(),setNs);
      yield return new Tuple<IId, IId>(setNs, setId);
    }
  }
}
