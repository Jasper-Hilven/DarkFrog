using System;
using System.Collections.Generic;
using DarkFrog.Id;
using DarkFrog.Namespacing;
using DarkFrog.Persistency;

namespace DarkFrog.Collections
{
  public class DfList : IPersistencyNameContainer, INameSpaceContainer
  {
    private static readonly RefId listId     = Naming.GetNamedId("ListId"); public static RefId ListId() { return listId; }
    private static readonly RefId listLength = Naming.GetNamedId("ListLength"); public static RefId ListLength() { return listLength; }
    private static readonly RefId listNs    = Naming.GetNamedId("ListNs"); public static RefId ListNs(){return listNs;}

    public static RefId CreateList()
    {
      return CreateList(new IId[0]);
    }
    public static RefId CreateList(IId[] elements)
    {
      var list = new RefId();
      var rawList = new RefId();
      list.SetProperty(listId, rawList);
      rawList.SetProperty(listLength, IntId.CreateId(elements.Length));
      for (int i = 0; i < elements.Length; i++)
      {
        rawList.SetProperty(IntId.CreateId(i),elements[i]);
      }
      return list;
    }

    public Dictionary<string, IId> GetPersistencyNamesFromIds()
    {
      return new Dictionary<string, IId>(){{"listId",listId},{"listLength",listLength}};
    }

    public string GetPrefix()
    {
      return "DfList";
    }

    public IEnumerable<Tuple<IId, IId>> GetHierarchy(NameSpaceBuilder builder)
    {
      yield return new Tuple<IId, IId>(builder.GetRoot(), listNs);
      yield return new Tuple<IId, IId>(listNs, listLength);
      yield return new Tuple<IId, IId>(listNs, listId);
    }
  }
}