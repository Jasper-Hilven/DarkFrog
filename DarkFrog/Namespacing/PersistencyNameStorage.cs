using System;
using System.Collections.Generic;
using DarkFrog.Collections;
using DarkFrog.Id;

namespace DarkFrog.Namespacing
{
  public class PersistencyNameStorage 
  {
    private readonly Environment environment;

    public PersistencyNameStorage(Environment environment)
    {
      this.environment = environment;
    }

    private void AddIId(IId iid, string unique)
    {
      environment.NameToId.Add(unique, iid);
      environment.IdToName.Add(iid, unique);
    }
    private void LoadStorageNames(IPersistencyNameContainer container)
    {
      var name = container.GetPrefix();
      foreach (var iId in container.GetIIds())
      {
        AddIId(iId.Value, name + ":" + iId.Key);
      }
    }
    public void LoadStorageNames()
    {
      environment.NameToId.Clear();
      environment.IdToName.Clear();
      LoadStorageNames(new NameSpaceBuilder());
      LoadStorageNames(new DfList());
      LoadStorageNames(new DfSet());
      LoadStorageNames(new Naming());
    }

  }

}
