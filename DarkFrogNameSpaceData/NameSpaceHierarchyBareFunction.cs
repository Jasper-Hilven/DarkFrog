using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkFrogNameSpaceData
{
  public class NameSpaceHierarchyBareFunction
  {
    public string name{get;set;}
    public List<NameSpaceFunctionType> InputTypes{get;set;}
    public NameSpaceFunctionType returnType{get;set;}
    public string BareCSharpCode{get;set;}
  }

}
