

namespace VisionsInCode.Foundation.Realtime.Models
{
  using System;
  using System.Collections.Generic;
  using MongoDB.Bson.Serialization.Attributes;
  using MongoDB.Bson.Serialization.Options;
  using VisionsInCode.Foundation.Realtime.Enums;

  [Serializable]
  public class VisitorDataContainer
  {
    private Dictionary<string, string> container = null;

   
    [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfDocuments)] 
    public Dictionary<string, string> Container
    {
      get { return container ?? (container = new Dictionary<string, string>()); }
      set { container = value; }
    }


    public bool ContainsParamkey(VisitorDataKeys realtimeUserKeys)
    {
      return Container != null && Container.ContainsKey(realtimeUserKeys.ToString());
    }

    public string GetValueByKey(VisitorDataKeys realtimeUserKeys)
    {

      string value;
      Container.TryGetValue(realtimeUserKeys.ToString(), out value);

      return value;
    }

    public void SetValueByKey(VisitorDataKeys realtimeUserKeys, string value)
    {

      if (Container.ContainsKey(realtimeUserKeys.ToString()))
        Container[realtimeUserKeys.ToString()] = value;
      else
        Container.Add(realtimeUserKeys.ToString(), value);
    }
  }
}