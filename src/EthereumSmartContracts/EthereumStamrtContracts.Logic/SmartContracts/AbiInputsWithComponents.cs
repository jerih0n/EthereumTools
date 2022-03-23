using Newtonsoft.Json;

namespace EthereumStamrtContracts.Logic.SmartContracts
{
    public class AbiInputsWithComponents
    {
        [JsonProperty("components")]
        public List<AbiObject> Components { get; set; }
    }
}