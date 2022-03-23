using EthereumStamrtContracts.Logic.SmartContracts;

namespace EthereumSmartContracts.App.SmartcontractDb
{
    public class SmartContractModel
    {
        public string ContractName { get; set; }

        public string ContractAddress { get; set; }

        public List<AbiObject> Abi { get; set; }
    }
}