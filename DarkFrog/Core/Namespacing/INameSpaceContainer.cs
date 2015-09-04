using System;
using System.Collections.Generic;
using DarkFrog.Core.Id;

namespace DarkFrog.Core.Namespacing
{
  public interface INameSpaceContainer
  {
    IEnumerable<Tuple<IId, IId>> GetHierarchy(NameSpaceBuilder builder);
  }
}
