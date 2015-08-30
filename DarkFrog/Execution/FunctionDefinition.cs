﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DarkFrog.Id;
using DarkFrog.Namespacing;

namespace DarkFrog.Execution
{
  class FunctionDefinition
  {
    private static readonly IId parameters = Naming.GetNamedId("parameters"); public static IId Parameters() { return parameters; }
    private static readonly IId subFunctionCalls = Naming.GetNamedId("SubFunctionCalls"); public static IId SubFunctionCalls(){return subFunctionCalls;}
    public static IId getCombinedFunctionDefinition(IId parameterSet, IId functionCallList)
    {
      var ret = new RefId();
      ret.SetProperty(parameters, parameterSet);
      ret.SetProperty(subFunctionCalls, functionCallList);
      return ret;
    }
    public static IId getCombinedFunctionDefinition(IId parameterSet, IId functionCallList, string name)
    {
      var ret = getCombinedFunctionDefinition(parameterSet, functionCallList);
      Naming.GiveNameToIId(name,ret);
      return ret;
    }
  }
}