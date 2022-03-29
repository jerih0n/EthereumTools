using Nethereum.Contracts;

namespace EthereumStamrtContracts.Logic.NethereumExtenstions
{
    public static class ContractExtenstion
    {
        public static ExtendedFunctionDecorator GetExtendedFunction(this Contract contract, string name)
        {
            return new ExtendedFunctionDecorator(contract, contract.ContractBuilder.GetFunctionBuilder(name));
        }
    }
}