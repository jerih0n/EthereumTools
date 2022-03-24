using Newtonsoft.Json;

namespace EthereumStamrtContracts.Logic.SmartContracts
{
    public class SmartContractBuildJson<TInput>
    {
        [JsonProperty("contractName")]
        public string ContractName { get; set; } = string.Empty;

        [JsonProperty("abi")]
        public List<AbiObject<TInput>>? Abi { get; set; }

        [JsonProperty("bytecode")]
        public string ByteCode { get; set; } = string.Empty;
    }
}