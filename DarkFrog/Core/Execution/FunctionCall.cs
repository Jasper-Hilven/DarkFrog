﻿using DarkFrog.Core.Id;
using DarkFrog.Core.Namespacing;

namespace DarkFrog.Core.Execution
{
  class FunctionCall
  {
    private static readonly IId parameterValues = Naming.GetNamedId("parameterValues"); public static IId ParameterValues() { return parameterValues; }
    private static readonly IId functionCalled = Naming.GetNamedId("functionCalled"); public static IId FunctionCalled() { return functionCalled; }

    public static IId GetFunctionCall(IId valueDictionary, IId callee)
    {
      var ret = RefId.CreateRefId();
      ret.SetProperty(parameterValues,valueDictionary);
      ret.SetProperty(functionCalled,callee);
      return ret;
    }
    public static IId GetFunctionCall(IId valueDictionary, IId callee, string name)
    {
      var ret = GetFunctionCall(valueDictionary, callee);
      Naming.GiveNameToIId(name,ret);
      return ret;
    }

  }
}
