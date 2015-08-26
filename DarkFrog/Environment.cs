using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DarkFrog.Id;
using DarkFrog.Namespacing;

namespace DarkFrog
{
  //Contains all variables and the loading and disloading of it
  public class Environment
  {
    public readonly IdStreamer Streamer;
    public bool Loaded { get; private set; }
    public Ns MyNamespacing;
    public Dictionary<IId, string> IdToName { get; private set; }
    public Dictionary<string,IId> NameToId{ get; private set; }

 
    public Environment()
    {
      NameToId = new Dictionary<string, IId>();
      IdToName = new Dictionary<IId, string>();
      MyNamespacing = new Ns(this);
      MyNamespacing.LoadNamespace();
      Streamer = new IdStreamer(this);
      Loaded = true;
    }

    public void LoadEnvironment(string path)
    {
      if(Loaded)
        UnLoadEnvironment();
      MyNamespacing.LoadNamespace();
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
      MyNamespacing = new Ns(this);

    }

    public IId GetRoot()
    {
      if(!Loaded)
        throw new Exception();
      return MyNamespacing.Root();
    }
  }
}
