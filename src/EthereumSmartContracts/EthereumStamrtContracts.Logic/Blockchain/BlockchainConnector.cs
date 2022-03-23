using EthereumStamrtContracts.Logic.Configuration.Models;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System.Numerics;

namespace EthereumStamrtContracts.Logic.Blockchain
{
    public class BlockchainConnector
    {
        private readonly Web3 _web3;

        public BlockchainConnector(NetworkConfiguration network, Account account)
        {
            var chainId = network.NetworkId;
            _web3 = new Web3(account, $"{network.RPCUrl}:{network.Port}");
            _web3.TransactionManager.UseLegacyAsDefault = true;
        }

        public async Task<BigInteger> GetEthBalance(string address)
             => await _web3.Eth.GetBalance.SendRequestAsync(address);
    }
}