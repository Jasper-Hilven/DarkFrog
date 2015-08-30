using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DarkFrog.Id;
using DarkFrog.Namespacing;

namespace DarkFrog.Execution
{
  class Execution : IPersistencyNameContainer, INameSpaceContainer
  {
    private static readonly IId executionNs = Naming.GetNamedId("ExecutionNs"); public static IId ExecutionNs() { return executionNs; }

    public Dictionary<string, IId> GetPersistencyNamesFromIds()
    {
      return new Dictionary<string, IId>()
             {
               { "ExecutionNs", executionNs }, 
               { "ParameterValues", FunctionCall.ParameterValues() },
               { "FunctionCalled", FunctionCall.FunctionCalled() },
               { "Parameters", FunctionDefinition.Parameters() }
             };
    }

    public string GetPrefix()
    {
      return "Execution";
    }

    public IEnumerable<Tuple<IId, IId>> GetHierarchy(NameSpaceBuilder builder)
    {
      yield return new Tuple<IId, IId>(builder.GetRoot(),executionNs);
      yield return new Tuple<IId, IId>(executionNs,FunctionCall.ParameterValues());
      yield return new Tuple<IId, IId>(executionNs,FunctionCall.FunctionCalled());
      yield return new Tuple<IId, IId>(executionNs,FunctionDefinition.Parameters());
    }
  }
}
