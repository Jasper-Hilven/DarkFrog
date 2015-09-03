﻿using System;
using System.Collections.Generic;

namespace DarkFrog.Id
{
  public abstract class BareFunctionId : IId
  {
    private static long stID = 0;
    private long id;

    protected BareFunctionId()
    {
      id = stID++;
    }
    public BareListId BareParametersList { get; private set; } 

    public abstract IId Execute(RefId parameters);

    public IEnumerable<IId> GetProperties()
    {
      yield return Execution.FunctionDefinition.BareParametersList();
    }

    public IEnumerable<IId> GetPropertiesAndValues()
    {
      yield return Execution.FunctionDefinition.BareParametersList();
      yield return BareParametersList;
    }

    public bool ContainsProperty(IId property)
    {
      return property.Equals(Execution.FunctionDefinition.BareParametersList());
    }

    public IId GetProperty(IId property)
    {
      if (!ContainsProperty(property))
        throw new Exception();
      return BareParametersList;
    }

    public void SetProperty(IId property, IId value)
    {
        throw new Exception();
    }

    public void RemoveProperty(IId property)
    {
      throw new Exception();
    }

    public bool IsRefIId()
    {
      return false;
    }

    public string GetStreamDescription()
    {
      return "BF" + id;
    }

    public string GetFullPropertyDescription()
    {
      return GetStreamDescription();
    }
  }
}