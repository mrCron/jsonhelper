using System;
using System.Collections.Generic;

namespace SKTools
{
    public static class DictionaryExtention
    {
        public static float GetFloat(this Dictionary<string, object> data, string key, 
            float def = 0, bool silent = true)
        {
            if (data.TryGetValue(key, out var value))
                return Convert.ToSingle(value);

            if (silent)
                return def;

            return (float)data[key]; // ! Exception 100%
        }

        public static int GetInt(this Dictionary<string, object> data, string key, 
            int def = 0, bool silent = true)
        {
            if (data.TryGetValue(key, out var value))
                return (int)(long)value;

            if (silent)
                return def;

            throw new Exception($"Key: {key} not found");
        }

        public static string GetString(this Dictionary<string, object> data, string key, 
            string def = null, bool silent = true)
        {
            if (data.TryGetValue(key, out var value))
                return value as string;

            if (silent)
                return def;

            throw new Exception($"Key: {key} not found");
        }

        public static Dictionary<string, object> GetDictionary(this Dictionary<string, object> data, string key, 
            Dictionary<string, object> def = null, bool silent = true)
        {
            if (data.TryGetValue(key, out var value))
                return value as Dictionary<string, object>;

            if (silent)
                return def;

            throw new Exception($"Key: {key} not found");
        }

        public static List<object> GetList(this Dictionary<string, object> data, string key, 
            List<object> def = null, bool silent = true)
        {
            if (data.TryGetValue(key, out var value))
                return value as List<object>;

            if (silent)
                return def;

            throw new Exception($"Key: {key} not found");
        }

        public static List<T> DeserialiseList<T>(this Dictionary<string, object> data, string key) where T : ISKSerializable, new()
        {
            var ret = new List<T>();

            foreach (var item in data.GetList(key, null, false))
            {
                var t = new T();
                t.Deserialize(item);
                ret.Add(t);
            }

            return ret;
        }
    }
}