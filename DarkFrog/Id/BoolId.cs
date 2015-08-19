namespace DarkFrog.Id
{
  public class BoolId : IId
  {
    public static BoolId True = new BoolId(true);
    public static BoolId False = new BoolId(false);
    private bool value;

    private BoolId(bool value)
    {
      this.value = value;
    }
    // ReSharper disable once ParameterHidesMember
    public BoolId GetBoolId(bool value)
    {
      return value ? True : False;
    }

    public bool ContainsProperty(IId property)
    {
      return false;
    }

    public IId GetProperty(IId property)
    {
      throw new System.Exception();
    }

    public void SetProperty(IId property, IId value)
    {
      throw new System.Exception();
    }

    public bool IsRefIId()
    {
      return false;
    }
  }
}