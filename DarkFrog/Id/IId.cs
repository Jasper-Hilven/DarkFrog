using System;
using System.Collections.Generic;

namespace DarkFrog.Id
{
  public interface IId
  {
    IEnumerable<IId> GetProperties();
    IEnumerable<IId> GetPropertiesAndValues(); 
    bool ContainsProperty(IId property);
    IId GetProperty(IId property);
    void SetProperty(IId property, IId value);
    void RemoveProperty(IId property);
    bool IsRefIId();
    string GetStreamDescription();
    string GetFullPropertyDescription();

  }
}