using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DarkFrog.Id;
using DarkFrog.Namespacing;

namespace DarkFrog.Collections
{
  class DfSet:INameContainer
  {
    private static readonly IId setId = new RefId(); public static IId SetId() { return setId; }
    private static readonly IId setProperty = new RefId(); public static IId SetProperty() { return setProperty; }

    public Dictionary<string, IId> GetIIds()
    {
      return new Dictionary<string, IId>(){{"setId",setId},{"setProperty", setProperty}};
    }

    public string GetPrefix()
    {
      return "DfSet";
    }
  }
}
