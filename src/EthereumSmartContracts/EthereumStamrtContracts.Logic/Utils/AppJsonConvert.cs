using EthereumStamrtContracts.Logic.SmartContracts;
using Newtonsoft.Json;

namespace EthereumStamrtContracts.Logic.Utils
{
    public static class AppJsonConvert
    {
        public static SmartContractBuildJson<AbiInputs> DeserializeSmartContractAbi(string abi)
        {
            var buildData = JsonConvert.DeserializeObject<SmartContractBuildJson<AbiInputs>>(abi);
            var buildDataWithComponents = JsonConvert.DeserializeObject<SmartContractBuildJson<AbiInputWithNestedComponents>>(abi);

            if (buildDataWithComponents != null || !buildDataWithComponents.Abi.Any())
            {
                foreach (var component in buildDataWithComponents.Abi)
                {
                }
            }

            return buildData;
        }
    }
}