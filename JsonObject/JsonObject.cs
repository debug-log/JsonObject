using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace JSON
{
    public class JsonObject
    {
        Dictionary<string, object> jsonObject;

        public JsonObject ()
        {
            this.jsonObject = new Dictionary<string, object> ();
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator ()
        {
            return jsonObject.GetEnumerator ();
        }

        public object Last ()
        {
            return jsonObject.Last ();
        }

        public object Get (string key)
        {
            if (jsonObject.ContainsKey (key))
            {
                return this.jsonObject[key];
            }
            return null;
        }

        public int GetInt (string key)
        {
            object value = this.Get (key);
            if (value == null)
            {
                throw new Exception (string.Format ("JSONObject[{0}] not found", key));
            }

            if (value is int)
            {
                return (int) value;
            }
            throw new Exception (string.Format ("JSONObject[{0}] is not an Int", key));
        }

        public float GetFloat (string key)
        {
            object value = this.Get (key);
            if (value == null)
            {
                throw new Exception (string.Format ("JSONObject[{0}] not found", key));
            }

            if (value is float)
            {
                return (float) value;
            }
            throw new Exception (string.Format ("JSONObject[{0}] is not a Number", key));
        }

        public bool GetBoolean (string key)
        {
            object value = this.Get (key);
            if (value == null)
            {
                throw new Exception (string.Format ("JSONObject[{0}] not found", key));
            }

            if (value is bool)
            {
                return (bool) value;
            }
            throw new Exception (string.Format ("JSONObject[{0}] is not a Boolean", key));
        }

        public string GetString (string key)
        {
            object value = this.Get (key);
            if (value == null)
            {
                throw new Exception (string.Format ("JSONObject[{0}] not found", key));
            }

            if (value is string)
            {
                return (string) value;
            }
            throw new Exception (string.Format ("JSONObject[{0}] is not a String", key));
        }

        public JsonObject GetJsonObject (string key)
        {
            object value = this.Get (key);
            if (value == null)
            {
                throw new Exception (string.Format ("JSONObject[{0}] not found", key));
            }

            if (value is JsonObject)
            {
                return (JsonObject) value;
            }
            throw new Exception (string.Format ("JSONObject[{0}] is not a JsonObject", key));
        }

        public JsonArray GetJsonArray (string key)
        {
            object value = this.Get (key);
            if (value == null)
            {
                throw new Exception (string.Format ("JSONObject[{0}] not found", key));
            }

            if (value is JsonArray)
            {
                return (JsonArray) value;
            }
            throw new Exception (string.Format ("JSONObject[{0}] is not a JsonArray", key));
        }

        public string ToJson (bool prettyPrint = false)
        {
            if (prettyPrint)
            {
                return new JsonPrettyPrint ().PrettyPrint (this);
            }
            else
            {
                return ToJson ();
            }
        }

        public bool HasKey (string key)
        {
            return this.jsonObject.ContainsKey (key);
        }

        public string[] Keys ()
        {
            return this.jsonObject.Keys.ToArray<string> ();
        }

        public void SetInt (string key, int value)
        {
            jsonObject.Add (key, value);
        }

        public void SetFloat (string key, float value)
        {
            jsonObject.Add (key, value);
        }

        public void SetBoolean (string key, bool value)
        {
            jsonObject.Add (key, value);
        }

        public void SetString (string key, string value)
        {
            jsonObject.Add (key, value);
        }

        public void SetJsonObject (string key, JsonObject value)
        {
            jsonObject.Add (key, value);
        }

        public void SetJsonArray (string key, JsonArray value)
        {
            jsonObject.Add (key, value);
        }

        public object Remove (string key)
        {
            object item = this.Get (key);
            this.jsonObject.Remove (key);
            return item;
        }

        string ToJson ()
        {
            StringBuilder stringBuilder = new StringBuilder ();

            stringBuilder.Append ("{");
            foreach (var item in jsonObject)
            {
                if (item.Value.GetType ().Equals (typeof (string)))
                {
                    stringBuilder.Append (string.Format ("\"{0}\": \"{1}\"", item.Key, item.Value));
                }
                else
                {
                    string value = (item.GetType ().Equals (typeof (bool))) ? item.Value.ToString ().ToLower () : item.Value.ToString ();
                    stringBuilder.Append (string.Format ("\"{0}\": {1}", item.Key, value));
                }

                if (!item.Equals (jsonObject.Last ()))
                {
                    stringBuilder.Append (',');
                }
            }
            stringBuilder.Append ("}");

            return stringBuilder.ToString ();
        }

        public override string ToString ()
        {
            return this.ToJson (prettyPrint: false);
        }
    }
}