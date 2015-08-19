using System.Collections.Generic;
using DarkFrog.Id;
using DarkFrog.Namespacing;

namespace DarkFrog.Collections
{
  public class DfList : INameContainer
  {
    private static readonly RefId listId = new RefId(); public static RefId ListId() { return listId; }
    private static readonly RefId listLength = new RefId(); public static RefId ListLength() { return listLength; }

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

    public Dictionary<string, IId> GetIIds()
    {
      return new Dictionary<string, IId>(){{"listId",listId},{"listLength",listLength}};
    }

    public string GetPrefix()
    {
      return "DfList";
    }
  }
}