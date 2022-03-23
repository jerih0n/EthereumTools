using EthereumStamrtContracts.Logic.Configuration.Models;
using Nethereum.Contracts;
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

        public BlockchainConnector(NetworkConfiguration network, Account account)
        {
            var chainId = network.NetworkId;
            _rpcUrl = network.RPCUrl;
            _port = network.Port;
            _web3 = new Web3(account, $"{NetworkUrl}");
            _web3.TransactionManager.UseLegacyAsDefault = true;
        }

        public string NetworkUrl
        { get { return $"{_rpcUrl}:{_port}"; } }

        public void UseAccount(Account account)
        {
            _web3 = new Web3(account, NetworkUrl);
        }

        public async Task<BigInteger> GetEthBalance(string address)
             => await _web3.Eth.GetBalance.SendRequestAsync(address);

        public async Task<object> CallNonTransactionResultingFunction(string abi, string contractAddress, string functionName, params object[] functionInput)
        {
            try
            {
                var contract = _web3.Eth.GetContract(abi, contractAddress);
                var function = contract.GetFunction(functionName);
                var txas = await function.CallAsync<object>(functionInput);

                return txas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}