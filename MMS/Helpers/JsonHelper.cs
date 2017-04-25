using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMS.Helpers
{
    public static class JsonHelper
    {
        public static Dictionary<string, object> ToJsonDictionary<TKey, TValue>(this Dictionary<TKey, TValue> input)
        {
            var output = new Dictionary<string, object>(input.Count);
            foreach (KeyValuePair<TKey, TValue> pair in input)
                output.Add(pair.Key.ToString(), pair.Value);
            return output;
        }
    }
}