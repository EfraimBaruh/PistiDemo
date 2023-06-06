using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Nakama.TinyJson;

public static class Utils
{

    /// <summary>
    /// Shuffles the element order of the specified list.
    /// </summary>
    public static void Shuffle<T>(this IList<T> ts)
    {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }

    public static void Resize<T>(this List<T> list, int newCount)
    {
        if (newCount <= 0)
        {
            list.Clear();
        }
        else
        {
            while (list.Count > newCount) list.RemoveAt(list.Count - 1);
            while (list.Count < newCount) list.Add(default(T));
        }
    }

    /// <summary>
    /// Converts a byte array of a UTF8 encoded JSON string into a Dictionary.
    /// </summary>
    /// <param name="state">The incoming state byte array.</param>
    /// <returns>A Dictionary containing state data as strings.</returns>
    public static IDictionary<string, string> GetStateAsDictionary(byte[] state)
    {
        return Encoding.UTF8.GetString(state).FromJson<Dictionary<string, string>>();
    }
    public static Dictionary<string, string> GetStringValueAsDictionary(string value)
    {
        Dictionary<string, string> value2 = value.FromJson<Dictionary<string, string>>();
        return value2;
    }

    public static Dictionary<string, int> GetIntValueAsDictionary(string value)
    {
        Dictionary<string, int> value2 = value.FromJson<Dictionary<string, int>>();
        return value2;
    }

    public static IDictionary<string, int> GetStateAsDictionary(string value)
    {
        Dictionary<string, int> value2 = value.FromJson<Dictionary<string, int>>();
        return value2;
    }

    public static IDictionary<string, int[]> GetIntArrayAsDictionary(string value)
    {
        Dictionary<string, int[]> valueArray = value.FromJson<Dictionary<string, int[]>>();
        return valueArray;
    }
    public static IDictionary<string, string[]> GetStringArrayAsDictionary(string value)
    {
        Dictionary<string, string[]> valueArray = value.FromJson<Dictionary<string, string[]>>();
        return valueArray;
    }


}
