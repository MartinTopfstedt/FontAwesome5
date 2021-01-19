using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FontAwesome5.Generator
{
    public class StringToArrayConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override bool CanWrite
        {
            get
            {
                return false;
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string[] arr = null;            // use null as default value
            if (reader.TokenType == JsonToken.StartArray)
            {
                JToken token = JToken.Load(reader);
                arr = token.ToObject<string[]>();
            }
            else
            {
                arr = new string[1] { reader.Value.ToString() };
            }
            return arr;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
