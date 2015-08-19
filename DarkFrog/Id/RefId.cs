using System.Collections.Generic;

namespace DarkFrog.Id
{
  public class RefId : IId
  {
    private static long stID = 0;
    private readonly Dictionary<IId, IId> values = new Dictionary<IId, IId>();
    private long id; //this id is only used for serialization. The unique pointer is used as real id when the environment is loaded
    
    public RefId()
    {
      this.id = stID++;
    }

    
    public bool ContainsProperty(IId property)
    {
      return values.ContainsKey(property);
    }

    public IId GetProperty(IId property)
    {
      return values[property];
    }

    public void SetProperty(IId property, IId value)
    {
      values[property] = value;
    }

    public bool IsRefIId()
    {
      return true;
    }
  }
}