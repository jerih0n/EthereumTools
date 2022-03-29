using Nethereum.ABI.Model;
using Nethereum.Contracts;

namespace EthereumStamrtContracts.Logic.NethereumExtenstions
{
    public class ExtendedFunctionDecorator : Function
    {
        public ExtendedFunctionDecorator(Contract contract, FunctionBuilder functionBuilder) : base(contract, functionBuilder)
        {
        }

        public void CallWithPredefinedReturnTypeAsync(object result, params object[] functionInput)
        {
            base.CallAsync(result, CreateCallInput(functionInput));
        }

        public async Task<List<object>> CallWithPredefinedReturnTypeAsync(List<object> result, params object[] functionInput)
        {
            return await base.CallAsync(result, CreateCallInput(functionInput));
        }
    }
}