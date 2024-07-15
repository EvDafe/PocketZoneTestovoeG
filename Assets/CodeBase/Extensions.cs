using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.ServicesScripts.Progress
{
    public static class Extensions
    {
        public static T FromJson<T>(this string yes) =>
            Newtonsoft.Json.JsonConvert.DeserializeObject<T>(yes, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All });

        public static string ToJson<T>(this T obj) =>
            Newtonsoft.Json.JsonConvert.SerializeObject(obj, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All });

        public static Vector3 RandomDirection(this Vector3 vector) =>
            new Vector3(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f)).normalized;

        public static void Shuffle<T>(this IList<T> list)
        {
            System.Random rng = new System.Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static Vector3 AddRandomOffset(this Vector3 vector, float multiple) =>
            new Vector3(vector.x + UnityEngine.Random.Range(0, 1f) * multiple, vector.y + UnityEngine.Random.Range(0, 1f) * multiple);

        public static T Random<T>(this IList<T> list) =>
            list.ElementAt(UnityEngine.Random.Range(0, list.Count));

        public static List<int> GetRandomIndexes<T>(this List<T> list ,int from, int to)
        {
            var random = new System.Random();
            HashSet<int> numbers = new HashSet<int>();
            while (numbers.Count < list.Count)
            {
                numbers.Add(random.Next(from, to));
            }
            return numbers.ToList();
        }

        public static T Random<T>(this List<T> list) =>
            list[UnityEngine.Random.Range(0, list.Count)];
    }
}
