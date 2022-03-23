using Newtonsoft.Json;

namespace EthereumStamrtContracts.Logic.SmartContracts
{
    public class SmartContractBuildJson
    {
        [JsonProperty("contractName")]
        public string? ContractName { get; set; }

        [JsonProperty("abi")]
        public List<AbiObject>? Abi { get; set; }
    }
}