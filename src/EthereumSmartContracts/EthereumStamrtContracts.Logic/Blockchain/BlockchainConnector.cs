﻿using EthereumStamrtContracts.Logic.Configuration.Models;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
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
                            var resultArray = await function.CallAsync<List<object>>(functionInput);
                            return resultArray;
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
    }
}