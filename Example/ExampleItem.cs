
using System.Collections.Generic;

namespace SKTools.Example
{
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