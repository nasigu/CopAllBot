using Newtonsoft.Json;
using Supreme.Core;

namespace Supreme.Model.Supreme
{
    internal class ProductSize
    {
        // In Supreme name is size)))
        [JsonProperty("name")]
        public Enums.Size Name { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("stock_level")]
        public long StockLevel { get; set; }
    }
}
