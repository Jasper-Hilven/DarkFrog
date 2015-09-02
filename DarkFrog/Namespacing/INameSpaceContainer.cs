using System;
using System.Collections.Generic;
using DarkFrog.Id;

namespace DarkFrog.Namespacing
{
  public interface INameSpaceContainer
  {
    IEnumerable<Tuple<IId, IId>> GetHierarchy(NameSpaceBuilder builder);
  }
}
