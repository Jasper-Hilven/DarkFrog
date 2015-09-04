using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkFrogNameSpaceData
{
  class NameSpaceDataBuilder
  {
    private static readonly IEnumerable<NameSpaceHierarchyNode> emptyChildren = new List<NameSpaceHierarchyNode>();
    private static readonly IEnumerable<NameSpaceHierarchyBareFunction> emptyElements = new List<NameSpaceHierarchyBareFunction>();
    private static readonly NameSpaceFunctionType intType = NameSpaceFunctionType.IntType;
    private static readonly NameSpaceFunctionType boolType = NameSpaceFunctionType.BoolType;
    private static readonly NameSpaceFunctionType iidType = NameSpaceFunctionType.IIdType;

    public static NameSpaceHierarchyNode getRoot()
    {
      var root = new NameSpaceHierarchyNode() { Name = "Root", Elements = emptyElements, Children = new List<NameSpaceHierarchyNode>() { GetIntHierarchy() ,GetExecutionHierarchy()} };
      return root;


    }

    public static NameSpaceHierarchyNode GetExecutionHierarchy()
    {
      var ifcall = new NameSpaceHierarchyBareFunction(){BareCSharpCode = "if(P0) then {R = P1;} else {R = P2;}",InputTypes =  new List<NameSpaceFunctionType>(){boolType,iidType,iidType},name = "if",returnType = iidType}
      
      var executionRoot = new NameSpaceHierarchyNode(){Name = "Execution",Children = emptyChildren,Elements = new List<NameSpaceHierarchyBareFunction>(){}};
      return executionRoot;
    }

    public static NameSpaceHierarchyNode GetIntHierarchy()
    {
      var sumFunction = new NameSpaceHierarchyBareFunction() { BareCSharpCode = "R = P0 + P1;", InputTypes = new List<NameSpaceFunctionType>() { intType, intType }, name = "+", returnType = intType };
      var minFunction = new NameSpaceHierarchyBareFunction() { BareCSharpCode = "R = P0 - P1;", InputTypes = new List<NameSpaceFunctionType>() { intType, intType }, name = "-", returnType = intType };
      var multFunction = new NameSpaceHierarchyBareFunction() { BareCSharpCode = "R = P0 * P1;", InputTypes = new List<NameSpaceFunctionType>() { intType, intType }, name = "*", returnType = intType };
      var divFunction = new NameSpaceHierarchyBareFunction() { BareCSharpCode = "R = P0 / P1;", InputTypes = new List<NameSpaceFunctionType>() { intType, intType }, name = "/", returnType = intType };
      var intmax = new NameSpaceHierarchyBareFunction() { BareCSharpCode = "R = Math.Max(P0, P1)", InputTypes = new List<NameSpaceFunctionType>() { intType, intType }, name = "Max", returnType = intType };
      var intmin = new NameSpaceHierarchyBareFunction() { BareCSharpCode = "R = Math.Min(P0, P1)", InputTypes = new List<NameSpaceFunctionType>() { intType, intType }, name = "Min", returnType = intType };
      var intRoot = new NameSpaceHierarchyNode()
      {Name = "Int", Elements = new List<NameSpaceHierarchyBareFunction>() { sumFunction, minFunction, multFunction, divFunction, intmax, intmin }, Children = emptyChildren};
      return intRoot;
    }
  }
}
