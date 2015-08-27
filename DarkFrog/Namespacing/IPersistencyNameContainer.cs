using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using DarkFrog.Id;

namespace DarkFrog.Namespacing
{
  public interface IPersistencyNameContainer
  {
    Dictionary<string, IId> GetIIds();
    string GetPrefix();

  }
}