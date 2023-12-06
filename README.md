# jsonhelper
 Extension to speed up work with serialization and deserialization

Contains a set of functions that help to serialize and deserialize classes implementing the ISKSerializable interface
Example implementation ISKSerializable
    public class ExampleItem : ISKSerializable
    {
        public int Id;
        public string Name;

        public object Serialize()
        {
            return new Dictionary<string, object>()
            {
                {"id", Id},
                {"name", Name},
            };
        }

        public void Deserialize(object data)
        {
            var info = data as Dictionary<string, object>;

            Id = info.GetInt("id");
            Name = info.GetString("name");
        }
    }
}

Example Dictionary
   //serialize
   var pack = new Dictionary<string, object>();
   pack.Add("list_group", listGroup.Serialize());
   
   string json = Json.Serialize(pack);

   //deserialize
   var dictionaryObject = Json.Deserialize(json) as Dictionary<string, object>;
   var result = dictionaryObject.DeserialiseList<ExampleGroupItem>("list_group");

Example List
  //serialize
   var pack = JsonHelper.Serialize(listGroup);
   string json = Json.Serialize(pack);

   //deserialize
   List<object> obj = Json.Deserialize(json) as List<object>;
   var result = JsonHelper.Deserialize<ExampleGroupItem>(obj);
