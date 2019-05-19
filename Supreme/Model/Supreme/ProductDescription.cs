using Newtonsoft.Json;
using System.Collections.Generic;

namespace Supreme.Model.Supreme
{
    internal class ProductDescription
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("description")]
        public object Description { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("image_url_hi")]
        public string ImageUrlHi { get; set; }

        [JsonProperty("swatch_url")]
        public string SwatchUrl { get; set; }

        [JsonProperty("swatch_url_hi")]
        public string SwatchUrlHi { get; set; }

        [JsonProperty("mobile_zoomed_url")]
        public string MobileZoomedUrl { get; set; }

        [JsonProperty("mobile_zoomed_url_hi")]
        public string MobileZoomedUrlHi { get; set; }

        [JsonProperty("bigger_zoomed_url")]
        public string BiggerZoomedUrl { get; set; }

        [JsonProperty("sizes")]
        public List<ProductSize> Sizes { get; set; }

        [JsonProperty("additional")]
        public List<object> Additional { get; set; }
    }
}
