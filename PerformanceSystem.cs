using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;

namespace JudgeSystem
{
    /// <summary>
    /// 保存实体性能指标信息
    /// </summary>
    public static class PerformanceSystem
    {
        private static readonly Dictionary<string, object> PerformanceData = new();
        
        public static object Get(string key)
        {
            if (PerformanceData.TryGetValue(key, out var value))
            {
                return value;
            }
            #if DEBUG 
            else {
                PerformanceData[key] = null;
            }
            #endif

            return null;
        }
        
        public static T Get<T>(string key)
        {
            if (PerformanceData.TryGetValue(key, out var value))
            {
                return (T) value;
            }
            #if DEBUG 
            else {
                PerformanceData[key] = default(T);
            }
            #endif

            return default;
        }
        
        public static bool TryGet(string key, out object value)
        {
            if (PerformanceData.TryGetValue(key, out var obj))
            {
                value = obj;
                return true;
            }
            #if DEBUG 
            else {
                PerformanceData[key] = null;
            }
            #endif
            value = null;
            return false;
        }
        
        public static bool TryGet<T>(string key, out T value)
        {
            if (PerformanceData.TryGetValue(key, out var obj))
            {
                value = (T) obj;
                return true;
            }
            #if DEBUG 
            else {
                PerformanceData[key] = default(T);
            }
            #endif
            value = default;
            return false;
        }

        public static void Inject(object obj)
        {
            foreach (var field in obj.GetType().GetFields().Where(f => f.GetCustomAttributes(typeof(PerformanceAttribute)).Count() != 0))
            {
                var attr = field.GetCustomAttribute<PerformanceAttribute>()!;
                field.SetValue(obj, Get(attr.Key));
            }
            
            foreach (var property in obj.GetType().GetProperties().Where(p => p.GetCustomAttributes(typeof(PerformanceAttribute)).Count() != 0))
            {
                var attr = property.GetCustomAttribute<PerformanceAttribute>()!;
                property.SetValue(obj, Get(attr.Key));
            }
        }
        
        public static void LoadFrom(byte[] data)
        {
            PerformanceData.Clear();
            
            var dt = JsonConvert.DeserializeObject<Dictionary<string, object>>(Encoding.UTF8.GetString(data));
            Flatten(dt);
            foreach (var pair in dt)
            {
                PerformanceData[pair.Key] = pair.Value;
            }
        }
        
        public static Stream SaveTo()
        {
            var dt = PerformanceData;
            Deflatten(dt);
            var json = JsonConvert.SerializeObject(dt);
            return new MemoryStream(Encoding.UTF8.GetBytes(json));
        }

        public static void SaveTo(string filePath)
        {
            using var stream = SaveTo();
            using var fileStream = new FileStream(filePath, FileMode.Create);
            stream.CopyTo(fileStream);
        }
        
        private static void Flatten(IDictionary<string, object> dict, string parentKey = "")
        {
            foreach (var pair in dict.ToArray())
            {
                dict.Remove(pair.Key);

                if (pair.Value is Dictionary<string, object> childDict)
                {
                    Flatten(childDict, parentKey + pair.Key + ".");
                }
                else
                {
                    dict[parentKey + pair.Key] = pair.Value;
                }
            }
        }
        
        private static void Deflatten(IDictionary<string, object> dict)
        {
            foreach (var pair in dict.ToArray())
            {
                dict.Remove(pair.Key);
                var keys = pair.Key.Split('.');
                var currentDict = dict;
                for (var i = 0; i < keys.Length - 1; i++)
                {
                    if (!currentDict.TryGetValue(keys[i], out var value))
                    {
                        value = new Dictionary<string, object>();
                        currentDict[keys[i]] = value;
                    }
                    currentDict = (Dictionary<string, object>) value;
                }
                currentDict[keys.Last()] = pair.Value;
            }
        }

        static PerformanceSystem()
        {
            #if DEBUG
            AppDomain.CurrentDomain.ProcessExit += (_, _) =>
            {
                SaveTo("performance.json");
                Console.WriteLine("Performance data saved to performance.json");
            };
            #endif
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class PerformanceAttribute : Attribute
    {
        public string Key { get; }
        public PerformanceAttribute(string key)
        {
            Key = key;
        }
    }
}