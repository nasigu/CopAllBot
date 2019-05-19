using Newtonsoft.Json;
using System.Collections.Generic;

namespace Supreme.Model.Supreme
{
    internal class MobileStock
    {
        [JsonProperty("products_and_categories")]
        public Dictionary<string, List<ProductsAndCategory>> ProductsAndCategories { get; set; }

        public static MobileStock FromJson(string json) => JsonConvert.DeserializeObject<MobileStock>(json, Core.Converters.Supreme.ProductAndCategoryJsonConverter.Settings);
    }
}
