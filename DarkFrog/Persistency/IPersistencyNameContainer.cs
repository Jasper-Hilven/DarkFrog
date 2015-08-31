using System.Collections.Generic;
using DarkFrog.Id;

namespace DarkFrog.Persistency
{
  public interface IPersistencyNameContainer
  {
    Dictionary<string, IId> GetPersistencyNamesFromIds();
    string GetPrefix();
  }
}