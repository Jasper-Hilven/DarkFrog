using System.Collections.Generic;
using DarkFrog.Collections;
using DarkFrog.Id;

namespace DarkFrog.Namespacing
{
  public class NameSpaceBuilder : IPersistencyNameContainer
  {
    private static readonly IId nsChildren = new RefId(); public static IId NsChildren() { return nsChildren; }

    public static void AddNameSpaceChild(IId parentId, IId childId)
    {
      if(!parentId.ContainsProperty(nsChildren))
        parentId.SetProperty(nsChildren,DfSet.CreateSet());
      var set = parentId.GetProperty(nsChildren);
      DfSet.AddToSet(set,childId);
    }

    public NameSpaceBuilder()
    {
    }

    private readonly IId root = new RefId(); 
    
    public IId GetRoot()
    {
      return root;
    }
    public Dictionary<string, IId> GetIIds()
    {
      return new Dictionary<string, IId>
             {
               {"root",root},
               { "nschildren", nsChildren }
             };
    }
    
    public string GetPrefix() { return "Hierarchy"; }

    public void BuildNameSpace()
    {
      var namespacecontainers = new HashSet<INameSpaceContainer>{new DfSet()};
      foreach (var nameSpaceContainer in namespacecontainers)
        AddRoot(nameSpaceContainer);
    }

    public void AddRoot(INameSpaceContainer container)
    {
      foreach (var tuple in container.GetHierarchy(this))
        AddNameSpaceChild(tuple.Item1,tuple.Item2);
    }

  }
}
