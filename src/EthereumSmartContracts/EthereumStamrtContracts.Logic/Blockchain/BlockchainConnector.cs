using EthereumStamrtContracts.Logic.Configuration.Models;
using EthereumStamrtContracts.Logic.Utils;
using Nethereum.ABI.FunctionEncoding;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System.Numerics;

namespace EthereumStamrtContracts.Logic.Blockchain
{
    public class BlockchainConnector
    {
        private Web3 _web3;
        private readonly string _rpcUrl;
        private readonly int _port;
        private string _currentSelectedAddress;
        private readonly HexBigInteger _defaultGassMax;
        private readonly HexBigInteger _defaultGassForTransaction;

        public BlockchainConnector(NetworkConfiguration network, Account account)

        {
            _rpcUrl = network.RPCUrl;
            _port = network.Port;
            _web3 = new Web3(account, $"{NetworkUrl}");
            _web3.TransactionManager.UseLegacyAsDefault = true;
            _defaultGassMax = new HexBigInteger(new BigInteger(network.GassPrice * 20));
            _defaultGassForTransaction = new HexBigInteger(new BigInteger(network.GassPrice * 3));
        }

        public string NetworkUrl
        { get { return $"{_rpcUrl}:{_port}"; } }

        public void UseAccount(Account account)
        {
            _web3 = new Web3(account, NetworkUrl);
            _web3.TransactionManager.UseLegacyAsDefault = true;
            _currentSelectedAddress = account.Address;
        }

        public async Task<BigInteger> GetEthBalance(string address)
             => await _web3.Eth.GetBalance.SendRequestAsync(address);

        public async Task<dynamic> CallSmartcontractFunction(string abi,
            string contractAddress,
            string functionName,
            FunctionTypesEnum functionType,
            bool multipleOutputs,
            bool complexOutput,
            HexBigInteger? ethAmountToSend,
            params object[] functionInput)
        {
            try
            {
                var contract = _web3.Eth.GetContract(abi, contractAddress);

                var function = contract.GetFunction(functionName);
                switch (functionType)
                {
                    case FunctionTypesEnum.ViewAndPure:
                        if (multipleOutputs)
                        {
                            if (complexOutput)
                            {
                                var smatcontractResponse = await function.CallDecodingToDefaultAsync(functionInput);
                                if (smatcontractResponse.Count > 1)
                                {
                                    return ExtractComplexOutput(smatcontractResponse);
                                }
                                if (smatcontractResponse.Count == 1)
                                {
                                    return ExtractComplexOutput((IEnumerable<object>)smatcontractResponse[0].Result);
                                }
                                return string.Empty;
                            }

                            return await function.CallAsync<List<object>>(functionInput);
                        }
                        //refactor!
                        if (complexOutput)
                        {
                            var smatcontractResponse = await function.CallDecodingToDefaultAsync(functionInput);
                            if (smatcontractResponse.Count > 1)
                            {
                                return ExtractComplexOutput(smatcontractResponse);
                            }
                            if (smatcontractResponse.Count == 1)
                            {
                                return ExtractComplexOutput((IEnumerable<object>)smatcontractResponse[0].Result);
                            }
                            return string.Empty;
                        }
                        var result = await function.CallAsync<object>(functionInput);
                        return result;

                    case FunctionTypesEnum.NonPayable:
                        var gass = await function.EstimateGasAsync(functionInput);
                        var transactionReciep = await function.SendTransactionAndWaitForReceiptAsync(_currentSelectedAddress, gass, null, null, functionInput);
                        return transactionReciep;

                    case FunctionTypesEnum.Payable:
                        gass = await function.EstimateGasAsync(functionInput);
                        if (ethAmountToSend == null) ethAmountToSend = new HexBigInteger(0);
                        gass.Value *= 2;
                        transactionReciep = await function.SendTransactionAndWaitForReceiptAsync(_currentSelectedAddress, gass, ethAmountToSend, null, functionInput);
                        return transactionReciep;

                    default:
                        throw new NotImplementedException();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Bad A*s recursion

        //OMG! This will be be better with JavaScript. I can't recognise myself anymore ...
        public List<string> ExtractComplexOutput(IEnumerable<object> outputs)
        {
            List<string> result = new List<string>();

            foreach (var output in outputs)
            {
                if (output is IEnumerable<object>)
                {
                    result.AddRange(ExtractComplexOutput((IEnumerable<object>)output));
                    continue;
                }
                if (output is ParameterOutput && ((ParameterOutput)output).Result is IEnumerable<object>)
                {
                    result.AddRange(ExtractComplexOutput((IEnumerable<object>)((ParameterOutput)output).Result));
                    continue;
                }
                var singleResult = output as ParameterOutput;
                if (singleResult?.Result is byte[])
                {
                    result.Add(((byte[])singleResult.Result).ToHex());
                    continue;
                }
                result.Add(singleResult.Result.ToString());
            }
            return result;
        }
    }
}