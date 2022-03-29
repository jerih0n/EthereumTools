using Newtonsoft.Json;

namespace EthereumStamrtContracts.Logic.SmartContracts
{
    public class AbiFieldsWithComponents
    {
        [JsonProperty("components")]
        public List<AbiFields> Components { get; set; }
    }
}