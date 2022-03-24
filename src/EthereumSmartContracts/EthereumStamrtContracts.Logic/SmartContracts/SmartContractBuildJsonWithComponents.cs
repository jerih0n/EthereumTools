using Newtonsoft.Json;

namespace EthereumStamrtContracts.Logic.SmartContracts
{
    public class SmartContractBuildJsonWithComponents
    {
        [JsonProperty("components")]
        public List<AbiInputsWithComponents> Abi { get; set; }
    }
}