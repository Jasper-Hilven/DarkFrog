﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DarkFrog.Id;

namespace DarkFrog.Namespacing
{
  class Naming:IPersistencyNameContainer
  {
    private static readonly IId nameTag = new RefId(); public IId NameTag() { return nameTag; }

    public static void GiveNameToIId(string name, IId id)
    {
      if(!id.IsRefIId())
        throw new Exception("Can only give names to ref IIds");
      id.SetProperty(nameTag,StringId.CreateStringId(name));
    }

    public static RefId GetNamedId(string name)
    {
      var retId = new RefId();
      retId.SetProperty(nameTag,StringId.CreateStringId(name));
      return retId;
    }

    public Dictionary<string, IId> GetIIds()
    {
      return new Dictionary<string, IId>
             {
               { "nameTag", nameTag}, 
             };
    }
    public string GetPrefix() { return "Naming"; }
  }
}
