using Newtonsoft.Json;
using System.Collections.Generic;

namespace Supreme.Model.Supreme
{
    internal class Product
    {
            [JsonProperty("styles")]
            public List<ProductDescription> Styles { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("can_add_styles")]
            public bool CanAddStyles { get; set; }

            [JsonProperty("can_buy_multiple")]
            public bool CanBuyMultiple { get; set; }

            [JsonProperty("ino")]
            public string Ino { get; set; }

            [JsonProperty("cod_blocked")]
            public bool CodBlocked { get; set; }

            [JsonProperty("canada_blocked")]
            public bool CanadaBlocked { get; set; }

            [JsonProperty("purchasable_qty")]
            public long PurchasableQty { get; set; }

            [JsonProperty("new_item")]
            public bool NewItem { get; set; }

            [JsonProperty("apparel")]
            public bool Apparel { get; set; }

            [JsonProperty("handling")]
            public long Handling { get; set; }

            [JsonProperty("no_free_shipping")]
            public bool NoFreeShipping { get; set; }

            [JsonProperty("can_buy_multiple_with_limit")]
            public long CanBuyMultipleWithLimit { get; set; }

            [JsonProperty("non_eu_blocked")]
            public bool NonEuBlocked { get; set; }

            [JsonProperty("russia_blocked")]
            public bool RussiaBlocked { get; set; }

        public static Product FromJson(string json) => JsonConvert.DeserializeObject<Product>(json, Core.Converters.Supreme.ProductJsonConverter.Settings);

    }

}
