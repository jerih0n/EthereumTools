using Newtonsoft.Json;

namespace EthereumStamrtContracts.Logic.SmartContracts
{
    public class AbiObject<TInput>
    {
        [JsonProperty("anonymous")]
        public bool? Anonymous { get; set; }

        [JsonProperty("inputs")]
        public List<TInput> Inputs { get; set; } = new List<TInput>();

        [JsonProperty("stateMutability")]
        public string? StateMutability { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("internalType")]
        public string InternalType { get; set; }

        [JsonProperty("outputs")]
        public List<AbiOuthputs> Outputs { get; set; } = new List<AbiOuthputs>();
    }
}