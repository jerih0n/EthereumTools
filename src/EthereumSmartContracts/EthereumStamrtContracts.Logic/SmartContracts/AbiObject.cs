using Newtonsoft.Json;

namespace EthereumStamrtContracts.Logic.SmartContracts
{
    public class AbiObject
    {
        [JsonProperty("anonymous")]
        public bool? Anonymous { get; set; }

        [JsonProperty("inputs")]
        public List<AbiImputs> Inputs { get; set; } = new List<AbiImputs>();

        [JsonProperty("inputs")]
        public List<AbiInputsWithComponents> InputsWithComponents { get; set; } = new List<AbiInputsWithComponents>();

        [JsonProperty("stateMutability")]
        public string? StateMutability { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("internalType")]
        public string InternalType { get; set; }

        [JsonProperty("outputs")]
        public List<AbiAuthputs> Outputs { get; set; } = new List<AbiAuthputs>();
    }
}