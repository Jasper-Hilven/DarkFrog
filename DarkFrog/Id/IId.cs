using System;

namespace DarkFrog.Id
{
  public interface IId
  {
    bool ContainsProperty(IId property);
    IId GetProperty(IId property);
    void SetProperty(IId property, IId value);
    bool IsRefIId();
  }
}