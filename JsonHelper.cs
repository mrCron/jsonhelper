
using System.Collections.Generic;

namespace SKTools
{
    public static class JsonHelper
    {
        public static List<object> Serialize<T>(this List<T> list) where T : ISKSerializable
        {
            var result = new List<object>();
        
            foreach (var item in list)
                result.Add(item.Serialize());

            return result;
        }
        
        public static List<T> Deserialize<T>(List<object> list) where T : ISKSerializable, new()
        {
            var result = new List<T>();

            foreach (var item in list)
            {
                T t = new T();
                t.Deserialize(item);
                
                result.Add(t);
            }

            return result;
        }
    }
    
}