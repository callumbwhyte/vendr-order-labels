using Newtonsoft.Json;

namespace Vendr.Contrib.OrderLabels.Web.Models.Response
{
    internal class LabelGeneratorResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("alias")]
        public string Alias { get; set; }
    }
}