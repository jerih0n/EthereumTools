using EthereumStamrtContracts.Logic.SmartContracts;

namespace EthereumSmartContracts.App.SmartcontractDb
{
    public class SmartContractModel
    {
        public string ContractName { get; set; }

        public string ContractAddress { get; set; }

        public List<dynamic> Abi { get; set; }

        public string ByteCode { get; set; }
    }
}