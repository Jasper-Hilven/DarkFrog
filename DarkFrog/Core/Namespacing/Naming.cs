﻿using System;
using System.Collections.Generic;
using DarkFrog.Core.Id;
using DarkFrog.Core.Persistency;

namespace DarkFrog.Core.Namespacing
{
  class Naming:IPersistencyNameContainer
  {
    private static readonly IId nameTag = RefId.CreateRefId(); public IId NameTag() { return nameTag; }

    public static void GiveNameToIId(string name, IId id)
    {
      if(!id.IsRefIId())
        throw new Exception("Can only give names to ref IIds");
      id.SetProperty(nameTag,StringId.CreateStringId(name));
    }

    public static RefId GetNamedId(string name)
    {
      var retId = RefId.CreateRefId();
      retId.SetProperty(nameTag,StringId.CreateStringId(name));
      return retId;
    }

    public Dictionary<string, IId> GetPersistencyNamesFromIds()
    {
      return new Dictionary<string, IId>
             {
               { "nameTag", nameTag}, 
             };
    }
    public string GetPrefix() { return "Naming"; }
  }
}

