using System;
using System.Collections.Generic;
using System.IO;
using DarkFrog.Id;
using DarkFrog.Namespacing;

namespace DarkFrog
{
  //Contains all variables and the loading and disloading of it
  public class Environment
  {
    public readonly IdStreamer Streamer;
    public bool Loaded { get; private set; }
    private PersistencyNameStorage persistencyNameStorage;
    public Dictionary<IId, string> IdToName { get; private set; }
    public Dictionary<string,IId> NameToId{ get; private set; }
    private NameSpaceBuilder nameSpaceBuilder;
 
    public Environment()
    {
      nameSpaceBuilder = new NameSpaceBuilder();
      nameSpaceBuilder.BuildNameSpace();
      NameToId = new Dictionary<string, IId>();
      IdToName = new Dictionary<IId, string>();
      persistencyNameStorage = new PersistencyNameStorage(this);
      persistencyNameStorage.LoadStorageNames();
      Streamer = new IdStreamer(this);
      Loaded = true;
    }

    public void LoadEnvironment(string path)
    {
      if(Loaded)
        UnLoadEnvironment();
      persistencyNameStorage.LoadStorageNames();
      throw new NotImplementedException();
      
      Loaded = true;
    }

    public void SaveEnvironment(string path)
    {
      File.WriteAllLines(path,Streamer.StreamAllIIds());
    }

    public void UnLoadEnvironment()
    {
      Loaded = false;
      NameToId = new Dictionary<string, IId>();
      IdToName = new Dictionary<IId, string>();
      persistencyNameStorage = new PersistencyNameStorage(this);

    }

    public IId GetRoot()
    {
      if(!Loaded)
        throw new Exception();
      return nameSpaceBuilder.GetRoot();
    }
  }
}
