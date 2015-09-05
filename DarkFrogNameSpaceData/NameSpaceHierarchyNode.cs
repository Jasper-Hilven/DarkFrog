using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkFrogNameSpaceData
{
  public class NameSpaceHierarchyNode
  {
    private NameSpaceHierarchyNode parent;
    private IEnumerable<NameSpaceHierarchyNode> children;

    public NameSpaceHierarchyNode Parent {
      get { return parent; }
    }
    public IEnumerable<NameSpaceHierarchyNode> Children {
      get { return children; }
      set
      {
        children = value;
        foreach (var nameSpaceHierarchyNode in value)
        {
          nameSpaceHierarchyNode.parent = this;
        }
      }
    }
    public IEnumerable<NameSpaceHierarchyBareFunction> Elements { get; set; }
    public string Name { get; set; }

    public List<string> Path
    {
      get
      {
        if (parent == null)
          return new List<string>(){Name};
        var parentPath = parent.Path;
        parentPath.Add(Name);
        return parentPath;
      }
    }
  }
}
