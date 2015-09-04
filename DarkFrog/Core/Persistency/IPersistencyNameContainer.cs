using System.Collections.Generic;
using DarkFrog.Core.Id;

namespace DarkFrog.Core.Persistency
{
  public interface IPersistencyNameContainer
  {
    Dictionary<string, IId> GetPersistencyNamesFromIds();
    string GetPrefix();
  }
}