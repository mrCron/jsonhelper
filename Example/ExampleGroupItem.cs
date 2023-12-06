
using System.Collections.Generic;

namespace SKTools.Example
{
    public class ExampleGroupItem : ISKSerializable
    {
        public int Id;
        public string Name;
        public List<ExampleItem> Items;

        public object Serialize()
        {
            return new Dictionary<string, object>()
            {
                {"id", Id},
                {"name", Name},
                {"items", Items.Serialize()}
            };
        }

        public void Deserialize(object data)
        {
            var info = data as Dictionary<string, object>;

            Id = info.GetInt("id");
            Name = info.GetString("name");
            Items = info.DeserialiseList<ExampleItem>("items");
        }
    }
}