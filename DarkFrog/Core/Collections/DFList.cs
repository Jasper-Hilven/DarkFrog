using System;
using System.Collections.Generic;
using DarkFrog.Core.Id;
using DarkFrog.Core.Namespacing;
using DarkFrog.Core.Persistency;

namespace DarkFrog.Core.Collections
{
  public class DfList : IPersistencyNameContainer, INameSpaceContainer
  {
    private static readonly RefId listId     = Naming.GetNamedId("ListId"); public static RefId ListId() { return listId; }
    private static readonly RefId listNs    = Naming.GetNamedId("ListNs"); public static RefId ListNs(){return listNs;}

    public static RefId CreateList()
    {
      return CreateList(new IId[0]);
    }
    public static RefId CreateList(IId[] elements)
    {
      var list = RefId.CreateRefId();
      var rawList = BareListId.CreateBareListId();
      list.SetProperty(listId, rawList);
      for (int i = 0; i < elements.Length; i++)
      {
        rawList.SetProperty(IntId.CreateId(i),elements[i]);
      }
      return list;
    }

    public Dictionary<string, IId> GetPersistencyNamesFromIds()
    {
      return new Dictionary<string, IId>(){{"listId",listId}};
    }

    public string GetPrefix()
    {
      return "DfList";
    }

    public IEnumerable<Tuple<IId, IId>> GetHierarchy(NameSpaceBuilder builder)
    {
      yield return new Tuple<IId, IId>(builder.GetRoot(), listNs);
      yield return new Tuple<IId, IId>(listNs, listId);
    }
  }
}