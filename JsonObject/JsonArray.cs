using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace JSON
{
    public class JsonArray
    {
        List<object> jsonList;

        public JsonArray ()
        {
            this.jsonList = new List<object> ();
        }

        public IEnumerator<object> GetEnumerator ()
        {
            return jsonList.GetEnumerator ();
        }

        public object Last ()
        {
            return this.jsonList.Last ();
        }

        public object Get (int index)
        {
            if (index < 0 || index >= this.jsonList.Count)
            {
                return null;
            }
            return jsonList[index];
        }

        public int GetInt (int index)
        {
            object value = this.Get (index);
            if (value == null)
            {
                throw new Exception (string.Format ("JsonArray[{0}] not found", index));
            }

            if (value is int)
            {
                return (int) value;
            }
            throw new Exception (string.Format ("JsonArray[{0}] is not an Int", index));
        }

        public float GetFloat (int index)
        {
            object value = this.Get (index);
            if (value == null)
            {
                throw new Exception (string.Format ("JsonArray[{0}] not found", index));
            }

            if (value is float)
            {
                return (float) value;
            }
            throw new Exception (string.Format ("JsonArray[{0}] is not a Number", index));
        }

        public bool GetBoolean (int index)
        {
            object value = this.Get (index);
            if (value == null)
            {
                throw new Exception (string.Format ("JsonArray[{0}] not found", index));
            }

            if (value is bool)
            {
                return (bool) value;
            }
            throw new Exception (string.Format ("JsonArray[{0}] is not a Boolean", index));
        }

        public string GetString (int index)
        {
            object value = this.Get (index);
            if (value == null)
            {
                throw new Exception (string.Format ("JsonArray[{0}] not found", index));
            }

            if (value is string)
            {
                return (string) value;
            }
            throw new Exception (string.Format ("JsonArray[{0}] is not a String", index));
        }

        public JsonObject GetJsonObject (int index)
        {
            object value = this.Get (index);
            if (value == null)
            {
                throw new Exception (string.Format ("JsonArray[{0}] not found", index));
            }

            if (value is JsonObject)
            {
                return (JsonObject) value;
            }
            throw new Exception (string.Format ("JsonArray[{0}] is not a JsonObject", index));
        }

        public JsonArray GetJsonArray (int index)
        {
            object value = this.Get (index);
            if (value == null)
            {
                throw new Exception (string.Format ("JsonArray[{0}] not found", index));
            }

            if (value is JsonArray)
            {
                return (JsonArray) value;
            }
            throw new Exception (string.Format ("JsonArray[{0}] is not a JsonArray", index));
        }

        public int Size ()
        {
            return this.jsonList.Count;
        }

        public void Append (int value)
        {
            jsonList.Add (value);
        }

        public void Append (float value)
        {
            jsonList.Add (value);
        }

        public void Append (bool value)
        {
            jsonList.Add (value);
        }

        public void Append (string value)
        {
            jsonList.Add (value);
        }

        public void Append (JsonObject value)
        {
            jsonList.Add (value);
        }

        public void Append (JsonArray value)
        {
            jsonList.Add (value);
        }

        public object Remove (int index)
        {
            object item = this.Get (index);
            this.jsonList.Remove (item);
            return item;
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

        string ToJson ()
        {
            StringBuilder stringBuilder = new StringBuilder ();

            stringBuilder.Append ("[");
            foreach (var item in jsonList)
            {
                if (item.GetType ().Equals (typeof (string)))
                {
                    stringBuilder.Append (string.Format ("\"{0}\"", item));
                }
                else
                {
                    string value = (item.GetType ().Equals (typeof (bool))) ? item.ToString ().ToLower () : item.ToString ();
                    stringBuilder.Append (string.Format ("{0}", value));
                }

                if (!item.Equals (jsonList.Last ()))
                {
                    stringBuilder.Append (',');
                }
            }
            stringBuilder.Append ("]");

            return stringBuilder.ToString ();
        }

        public override string ToString ()
        {
            return this.ToJson (prettyPrint: false);
        }
    }
}