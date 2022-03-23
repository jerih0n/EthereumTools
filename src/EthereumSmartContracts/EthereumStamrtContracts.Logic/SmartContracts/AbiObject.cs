using Newtonsoft.Json;

namespace EthereumStamrtContracts.Logic.SmartContracts
{
    public class AbiObject
    {
        [JsonProperty("anonymous")]
        public bool? Anonymous { get; set; }

        [JsonProperty("inputs")]
        public List<AbiImputs> Imputs { get; set; } = new List<AbiImputs>();

        [JsonProperty("stateMutability")]
        public string? StateMutability { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("internalType")]
        public string InternalType { get; set; }
    }
}