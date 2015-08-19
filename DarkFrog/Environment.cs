using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DarkFrog.Id;
using DarkFrog.Namespacing;

namespace DarkFrog
{
  //Contains all variables and the loading and disloading of it
  class Environment
  {
    public readonly IdStreamer Streamer;
    public bool Loaded { get; private set; }
    public Namespacing.Ns MyNamespacing;
    public Dictionary<IId, string> IdToName { get; private set; }
    public Dictionary<string,IId> NameToId{ get; private set; }

 
    public Environment(IdStreamer streamer)
    {
      this.MyNamespacing = new Ns(this);
      Streamer = streamer;
    }

    public void LoadEnvironment(string path)
    {
      if(Loaded)
        throw new Exception();
      MyNamespacing.LoadNamespace();
      throw new NotImplementedException();
      
      Loaded = true;
    }

    public void SaveEnvironment(string path)
    {
      if(!Loaded)
        throw new Exception();
      throw new NotImplementedException();
    }

    public void UnLoadEnvironment()
    {
      throw new NotImplementedException();
      Loaded = false;
    }

    public IId GetRoot()
    {
      throw new NotImplementedException();
    }
  }
}
