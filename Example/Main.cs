using System.Collections.Generic;
using MiniJSON;
using UnityEngine;

namespace SKTools.Example
{
    public class Main : MonoBehaviour
    {
        private void Start()
        {
            ExampleDictionary();
            ExampleList();
        }

        void ExampleDictionary()
        {
            // test data
            var listGroup = GetTestItems();
            
            //serialize
            var pack = new Dictionary<string, object>();
            pack.Add("list_group", listGroup.Serialize());
            
            string json = Json.Serialize(pack);
            
            // print
            Debug.Log(json);

            //deserialize
            var dictionaryObject = Json.Deserialize(json) as Dictionary<string, object>;
            var result = dictionaryObject.DeserialiseList<ExampleGroupItem>("list_group");
            
        }


        void ExampleList()
        {
            // test data
            var listGroup = GetTestItems();
            
            //serialize
            var pack = JsonHelper.Serialize(listGroup);
            string json = Json.Serialize(pack);

            // print
            Debug.Log(json);

            //deserialize
            List<object> obj = Json.Deserialize(json) as List<object>;
            var result = JsonHelper.Deserialize<ExampleGroupItem>(obj);
        }

        List<ExampleGroupItem> GetTestItems()
        {
            return new List<ExampleGroupItem>()
            {
                new ExampleGroupItem()
                {
                    Id = 1, Name = "group 1", Items = new List<ExampleItem>()
                    {
                        new ExampleItem()
                        {
                            Id = 1,
                            Name = "item 1"
                        },
                        new ExampleItem()
                        {
                            Id = 2,
                            Name = "item 2"
                        }
                    }
                },
                new ExampleGroupItem()
                {
                    Id = 1, Name = "group 2", Items = new List<ExampleItem>()
                    {
                        new ExampleItem()
                        {
                            Id = 21,
                            Name = "item 21"
                        },
                        new ExampleItem()
                        {
                            Id = 22,
                            Name = "item 22"
                        },
                        new ExampleItem()
                        {
                            Id = 23,
                            Name = "item 23"
                        }
                    }
                },

            };
        }
    }
}