using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace Supreme.Core.Converters.Supreme
{
    internal static class ProductJsonConverter
    {   
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                SizeConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
