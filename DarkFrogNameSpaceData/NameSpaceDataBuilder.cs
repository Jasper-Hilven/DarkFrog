using System.Collections.Generic;

namespace DarkFrogNameSpaceData
{
  class NameSpaceDataBuilder
  {
    private static readonly IEnumerable<NameSpaceHierarchyNode> emptyChildren = new List<NameSpaceHierarchyNode>();
    private static readonly IEnumerable<NameSpaceHierarchyBareFunction> emptyElements = new List<NameSpaceHierarchyBareFunction>();
    private static readonly NameSpaceFunctionType intType = NameSpaceFunctionType.IntType;
    private static readonly NameSpaceFunctionType boolType = NameSpaceFunctionType.BoolType;
    private static readonly NameSpaceFunctionType iidType = NameSpaceFunctionType.IIdType;
    private static readonly NameSpaceFunctionType refType = NameSpaceFunctionType.RefType;
    private static readonly NameSpaceFunctionType voidType = NameSpaceFunctionType.VoidType;
    private static readonly NameSpaceFunctionType listType = NameSpaceFunctionType.ListType;
    
    public static NameSpaceHierarchyNode GetRoot()
    {
      var root = new NameSpaceHierarchyNode() { Name = "Root", Elements = emptyElements, Children = new List<NameSpaceHierarchyNode>() { GetIntHierarchy(), GetExecutionHierarchy(), GetPropertyHierarchy() } };
      return root;
    }

    private static NameSpaceHierarchyNode GetExecutionHierarchy()
    {
      var ifcall = new NameSpaceHierarchyBareFunction { BareCSharpCode = "if(P0) then {R = P1;} else {R = P2;}", InputTypes = new List<NameSpaceFunctionType> { boolType, iidType, iidType }, name = "if", returnType = iidType };
      var executionRoot = new NameSpaceHierarchyNode { Name = "Execution", Children = emptyChildren, Elements = new List<NameSpaceHierarchyBareFunction>() { ifcall} };
      return executionRoot;
    }

    private static NameSpaceHierarchyNode GetPropertyHierarchy()
    {
      var getCall = new NameSpaceHierarchyBareFunction { BareCSharpCode = "R = P0.GetProperty(P1)", InputTypes = new List<NameSpaceFunctionType> { refType, iidType }, name = "Get", returnType = iidType};
      var setCall = new NameSpaceHierarchyBareFunction { BareCSharpCode = "P0.SetProperty(P1,P2)", InputTypes = new List<NameSpaceFunctionType> { refType, iidType, iidType }, name = "Set", returnType = voidType };
      var removeCall = new NameSpaceHierarchyBareFunction { BareCSharpCode = "P0.RemoveProperty(P1)", InputTypes = new List<NameSpaceFunctionType> { refType, iidType}, name = "Remove", returnType = voidType };
      var getPropertiesCall = new NameSpaceHierarchyBareFunction { BareCSharpCode = "R = P0.GetProperties().ToList()", InputTypes = new List<NameSpaceFunctionType> { refType}, name = "GetProperties", returnType = listType};
      var containsPropertyCall = new NameSpaceHierarchyBareFunction { BareCSharpCode = "R = P0.ContainsProperty(P1)", InputTypes = new List<NameSpaceFunctionType> { refType,iidType}, name = "ContainsProperty", returnType = boolType};
      var propertyRoot = new NameSpaceHierarchyNode { Name = "Property", Elements = new List<NameSpaceHierarchyBareFunction>() { getCall, setCall, removeCall, getPropertiesCall, containsPropertyCall}, Children = emptyChildren};
      return propertyRoot;
    }

    private static NameSpaceHierarchyNode GetIntHierarchy()
    {
      var sumFunction = new NameSpaceHierarchyBareFunction { BareCSharpCode = "R = P0 + P1;", InputTypes = new List<NameSpaceFunctionType> { intType, intType }, name = "+", returnType = intType };
      var minFunction = new NameSpaceHierarchyBareFunction { BareCSharpCode = "R = P0 - P1;", InputTypes = new List<NameSpaceFunctionType> { intType, intType }, name = "-", returnType = intType };
      var multFunction = new NameSpaceHierarchyBareFunction { BareCSharpCode = "R = P0 * P1;", InputTypes = new List<NameSpaceFunctionType> { intType, intType }, name = "*", returnType = intType };
      var divFunction = new NameSpaceHierarchyBareFunction { BareCSharpCode = "R = P0 / P1;", InputTypes = new List<NameSpaceFunctionType> { intType, intType }, name = "/", returnType = intType };
      var intmax = new NameSpaceHierarchyBareFunction { BareCSharpCode = "R = Math.Max(P0, P1)", InputTypes = new List<NameSpaceFunctionType> { intType, intType }, name = "Max", returnType = intType };
      var intmin = new NameSpaceHierarchyBareFunction { BareCSharpCode = "R = Math.Min(P0, P1)", InputTypes = new List<NameSpaceFunctionType> { intType, intType }, name = "Min", returnType = intType };
      var intRoot = new NameSpaceHierarchyNode { Name = "Int", Elements = new List<NameSpaceHierarchyBareFunction>() { sumFunction, minFunction, multFunction, divFunction, intmax, intmin }, Children = emptyChildren };
      return intRoot;
    }
  }
}
