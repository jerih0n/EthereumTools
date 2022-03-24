using Newtonsoft.Json;

namespace EthereumStamrtContracts.Logic.SmartContracts
{
    public class AbiInputWithNestedComponents
    {
        [JsonProperty("components")]
        public List<AbiInputs> Components { get; set; }
    }
}