using Newtonsoft.Json;

namespace EthereumStamrtContracts.Logic.SmartContracts
{
    public class AbiOuthputs
    {
        [JsonProperty("internalType")]
        public string InternalType { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}