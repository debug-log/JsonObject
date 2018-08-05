using System.Text;

namespace JSON
{
    public class JsonPrettyPrint
    {
        public string PrettyPrint (JsonObject jsonObject, int bracketCount = 0)
        {
            StringBuilder stringBuilder = new StringBuilder ();

            stringBuilder.Append ("{\n");
            bracketCount++;

            foreach (var item in jsonObject)
            {
                stringBuilder.Append (this.StringWithTab (bracketCount));

                if (item.Value.GetType ().Equals (typeof (string)))
                {
                    stringBuilder.Append (string.Format ("\"{0}\": \"{1}\"", item.Key, item.Value));
                }
                else if (item.Value.GetType ().Equals (typeof (bool)))
                {
                    stringBuilder.Append (string.Format ("\"{0}\": {1}", item.Key, item.Value.ToString ().ToLower ()));
                }
                else if (item.Value.GetType ().Equals (typeof (JsonObject)))
                {
                    stringBuilder.Append (string.Format ("\"{0}\": {1}", item.Key, this.PrettyPrint (item.Value as JsonObject, bracketCount)));
                }
                else if (item.Value.GetType ().Equals (typeof (JsonArray)))
                {
                    stringBuilder.Append (string.Format ("\"{0}\": {1}", item.Key, this.PrettyPrint (item.Value as JsonArray, bracketCount)));
                }
                else
                {
                    stringBuilder.Append (string.Format ("\"{0}\": {1}", item.Key, item.Value));
                }

                if (!item.Equals (jsonObject.Last ()))
                {
                    stringBuilder.Append (",\n");
                }
            }
            bracketCount--;
            stringBuilder.Append ("\n");
            stringBuilder.Append (this.StringWithTab (bracketCount));
            stringBuilder.Append ("}");

            return stringBuilder.ToString ();
        }

        public string PrettyPrint (JsonArray jsonArray, int bracketCount = 0)
        {
            StringBuilder stringBuilder = new StringBuilder ();

            stringBuilder.Append ("[\n");
            bracketCount++;

            foreach (var item in jsonArray)
            {
                stringBuilder.Append (this.StringWithTab (bracketCount));

                if (item.GetType ().Equals (typeof (string)))
                {
                    stringBuilder.Append (string.Format ("\"{0}\"", item));
                }
                else if (item.GetType ().Equals (typeof (bool)))
                {
                    stringBuilder.Append (string.Format ("{0}", item.ToString ().ToLower ()));
                }
                else if (item.GetType ().Equals (typeof (JsonObject)))
                {
                    stringBuilder.Append (string.Format ("{0}", this.PrettyPrint (item as JsonObject, bracketCount)));
                }
                else if (item.GetType ().Equals (typeof (JsonArray)))
                {
                    stringBuilder.Append (string.Format ("{0}", this.PrettyPrint (item as JsonArray, bracketCount)));
                }
                else
                {
                    stringBuilder.Append (string.Format ("{0}", item));
                }

                if (!item.Equals (jsonArray.Last ()))
                {
                    stringBuilder.Append (",\n");
                }
            }
            bracketCount--;
            stringBuilder.Append ("\n");
            stringBuilder.Append (this.StringWithTab (bracketCount));
            stringBuilder.Append ("]");

            return stringBuilder.ToString ();
        }

        string StringWithTab (int tabCount)
        {
            StringBuilder stringBuilder = new StringBuilder ();
            for (int i = 0; i < tabCount; ++i)
            {
                stringBuilder.Append ('\t');
            }
            return stringBuilder.ToString ();
        }
    }
}