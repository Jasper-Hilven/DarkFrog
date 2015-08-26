using System.Collections.Generic;
using System.Text;

namespace DarkFrog.Id
{
  public class RefId : IId
  {
    private static long stID = 0;
    private readonly Dictionary<IId, IId> values = new Dictionary<IId, IId>();

    private long id;
      //this id is only used for serialization. The unique pointer is used as real id when the environment is loaded

    public RefId()
    {
      this.id = stID++;
    }


    public IEnumerable<IId> GetProperties()
    {
      return values.Keys;
    }

    public IEnumerable<IId> GetPropertiesAndValues()
    {
      foreach (var value in values)
      {
        yield return value.Key;
        yield return value.Value;
      }
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

    public void RemoveProperty(IId property)
    {
      values.Remove(property);
    }

    public bool IsRefIId()
    {
      return true;
    }

    public string GetFullPropertyDescription()
    {      
      var ret = new StringBuilder(GetStreamDescription());
      foreach (var kp in values)
        ret.Append(kp.Key.GetStreamDescription() + " " + kp.Value.GetStreamDescription());
      return ret.ToString();
    }

    public string GetStreamDescription()
    {
      return "R" + id + " ";
    }
  }
}