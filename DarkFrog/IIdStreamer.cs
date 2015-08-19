using System;
using System.Collections.Generic;
using DarkFrog.Id;

namespace DarkFrog
{
  public class IdStreamer
  {
    private readonly Dictionary<string,IId> uniqueNames  = new Dictionary<string, IId>();
    public string[] StreamAllIIds(IId root)
    {
      throw new NotImplementedException();
    }

    public IId LoadAllIId(string[] text)
    {
      throw new NotImplementedException();
    }
    
    public RefId RegisterAndCreateUniqueIId(string uniqueName)
    {
      if (uniqueNames.ContainsKey(uniqueName))
        throw new System.Exception();
      var ret = new RefId();
      uniqueNames.Add(uniqueName, ret);
      return ret;
    }



  }
}