using DarkFrog.Core.Id;
using DarkFrog.Core.Namespacing;

namespace DarkFrog.Core.Execution
{
  class FunctionDefinition
  {
    private static readonly IId parameters = Naming.GetNamedId("parameters"); public static IId Parameters() { return parameters; }
    private static readonly IId subFunctionCalls = Naming.GetNamedId("SubFunctionCalls"); public static IId SubFunctionCalls(){return subFunctionCalls;}
    private static readonly IId bareParametersList = Naming.GetNamedId("BareParameterList"); public static IId BareParametersList(){return bareParametersList;}
    public static IId getCombinedFunctionDefinition(IId parameterSet, IId functionCallList)
    {
      var ret = RefId.CreateRefId();
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
