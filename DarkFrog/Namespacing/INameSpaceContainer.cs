using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DarkFrog.Id;

namespace DarkFrog.Namespacing
{
  public interface INameSpaceContainer
  {
    IEnumerable<Tuple<IId, IId>> GetHierarchy(NameSpaceBuilder builder);
  }
}
