using Newtonsoft.Json;
using System;


namespace Supreme.Core.Converters.Supreme
{
    internal class SizeConverter : JsonConverter
    {

        public override bool CanConvert(Type t) => t == typeof(Enums.Size) || t == typeof(Enums.Size?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Small":
                    return Enums.Size.Small;
                case "Medium":
                    return Enums.Size.Medium;
                case "Large":
                    return Enums.Size.Large;
                case "XLarge":
                    return Enums.Size.XLarge;
            }
            throw new Exception("Cannot unmarshal type Size");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Enums.Size)untypedValue;
            switch (value)
            {
                case Enums.Size.Small:
                    serializer.Serialize(writer, "Small");
                    return;
                case Enums.Size.Medium:
                    serializer.Serialize(writer, "Medium");
                    return;
                case Enums.Size.Large:
                    serializer.Serialize(writer, "Large");
                    return;
                case Enums.Size.XLarge:
                    serializer.Serialize(writer, "XLarge");
                    return;
            }
            throw new Exception("Cannot marshal type Size");
        }

        public static readonly SizeConverter Singleton = new SizeConverter();
    }
}

