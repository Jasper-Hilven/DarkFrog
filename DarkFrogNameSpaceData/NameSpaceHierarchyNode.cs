using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkFrogNameSpaceData
{
  class NameSpaceHierarchyNode
  {
    public IEnumerable<NameSpaceHierarchyNode> Children { get; set; }
    public IEnumerable<NameSpaceHierarchyBareFunction> Elements { get; set; }
    public string Name { get; set; }
  }
}
