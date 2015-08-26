using System;
using System.Collections.Generic;
using DarkFrog.Collections;
using DarkFrog.Id;

namespace DarkFrog.Namespacing
{
  public class Ns : INameContainer
  {
    private readonly Environment environment;

    public Ns(Environment environment)
    {
      this.environment = environment;
    }

    private void AddIId(IId iid, string unique)
    {
      environment.NameToId.Add(unique, iid);
      environment.IdToName.Add(iid, unique);
    }
    private void LoadNameSpace(INameContainer container)
    {
      var name = container.GetPrefix();
      foreach (var iId in container.GetIIds())
      {
        AddIId(iId.Value, name + ":" + iId.Key);
      }
    }
    public void LoadNamespace()
    {
      environment.NameToId.Clear();
      environment.IdToName.Clear();
      LoadNameSpace(this);
      LoadNameSpace(new DfList());
      LoadNameSpace(new DfSet());
    }

    private readonly IId root = new RefId(); public IId Root() { return root; }
    private readonly IId nsChildren = new RefId(); public IId NsChildren() { return nsChildren; }
    
    public Dictionary<string, IId> GetIIds() 
    
    { return new Dictionary<string, IId>
             {
               { "root", root }, 
               { "nschildren", nsChildren }
             }; }
    public string GetPrefix(){return "Ns";}
  }

}
