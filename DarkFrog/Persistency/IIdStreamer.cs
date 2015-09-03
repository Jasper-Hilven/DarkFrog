using System;
using System.Collections.Generic;
using System.Linq;
using DarkFrog.Id;

namespace DarkFrog.Persistency
{
  public class IdStreamer
  {
    private Environment environment;

    public IdStreamer(Environment environment)
    {
      this.environment = environment;
    }

    public IEnumerable<string> StreamAllIIds()
    {
      var isStreaming = RefId.CreateRefId();
      var streamList = new List<string>(){"IID"};
      AddIdAndMark(environment.GetRoot(),streamList,isStreaming);
      UnMark(environment.GetRoot(),isStreaming);
      streamList.Add("NAMES");
      WriteUniqueNames(environment.NameToId,streamList);
      return streamList;
    }

    private void WriteUniqueNames(Dictionary<string, IId> names, List<string> stream)
    {
      stream.AddRange(names.Select(kvp => string.Join("", kvp.Key.Select(c => ((int)c).ToString("X2"))) + " " + kvp.Value.GetStreamDescription()));
      stream.AddRange(names.Select(kvp => kvp.Key + " " + kvp.Value.GetStreamDescription()));
      
    }

    private void AddIdAndMark(IId target,List<string> acc,IId isStreaming)
    {
      if (!target.IsRefIId())
        return;
      if (target.ContainsProperty(isStreaming))
        return;
      acc.Add(target.GetFullPropertyDescription());
      target.SetProperty(isStreaming, isStreaming); 
      foreach (var propertiesAndValue in target.GetPropertiesAndValues().Where(o => o != isStreaming))
        AddIdAndMark(propertiesAndValue,acc,isStreaming);
    }

    private void UnMark(IId target, IId isStreaming)
    {
      if (!target.IsRefIId())
        return;
      if (!target.ContainsProperty(isStreaming))
        return;
      target.RemoveProperty(isStreaming);
    }

    public IId LoadAllIId(string[] text)
    {
      throw new NotImplementedException();
    }
    
    public RefId RegisterAndCreateUniqueIId(string uniqueName)
    {
      if (environment.NameToId.ContainsKey(uniqueName))
        throw new Exception();
      var ret = RefId.CreateRefId();
      environment.NameToId.Add(uniqueName, ret);
      return ret;
    }
  }
}