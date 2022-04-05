using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using SmartcontractTest.Contracts.SolidityTest.ContractDefinition;

namespace SmartcontractTest.Contracts.SolidityTest
{
    public partial class SolidityTestService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, SolidityTestDeployment solidityTestDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<SolidityTestDeployment>().SendRequestAndWaitForReceiptAsync(solidityTestDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, SolidityTestDeployment solidityTestDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<SolidityTestDeployment>().SendRequestAsync(solidityTestDeployment);
        }

        public static async Task<SolidityTestService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, SolidityTestDeployment solidityTestDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, solidityTestDeployment, cancellationTokenSource);
            return new SolidityTestService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public SolidityTestService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<BigInteger> CounterQueryAsync(CounterFunction counterFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CounterFunction, BigInteger>(counterFunction, blockParameter);
        }

        
        public Task<BigInteger> CounterQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CounterFunction, BigInteger>(null, blockParameter);
        }

        public Task<List<BigInteger>> GetArrayAsInputQueryAsync(GetArrayAsInputFunction getArrayAsInputFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetArrayAsInputFunction, List<BigInteger>>(getArrayAsInputFunction, blockParameter);
        }

        
        public Task<List<BigInteger>> GetArrayAsInputQueryAsync(List<BigInteger> arrayInput, BlockParameter blockParameter = null)
        {
            var getArrayAsInputFunction = new GetArrayAsInputFunction();
                getArrayAsInputFunction.ArrayInput = arrayInput;
            
            return ContractHandler.QueryAsync<GetArrayAsInputFunction, List<BigInteger>>(getArrayAsInputFunction, blockParameter);
        }

        public Task<GetArrayOfSctructsOutputDTO> GetArrayOfSctructsQueryAsync(GetArrayOfSctructsFunction getArrayOfSctructsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetArrayOfSctructsFunction, GetArrayOfSctructsOutputDTO>(getArrayOfSctructsFunction, blockParameter);
        }

        public Task<GetArrayOfSctructsOutputDTO> GetArrayOfSctructsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetArrayOfSctructsFunction, GetArrayOfSctructsOutputDTO>(null, blockParameter);
        }

        public Task<GetArrayOfStructsOutputDTO> GetArrayOfStructsQueryAsync(GetArrayOfStructsFunction getArrayOfStructsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetArrayOfStructsFunction, GetArrayOfStructsOutputDTO>(getArrayOfStructsFunction, blockParameter);
        }

        public Task<GetArrayOfStructsOutputDTO> GetArrayOfStructsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetArrayOfStructsFunction, GetArrayOfStructsOutputDTO>(null, blockParameter);
        }

        public Task<List<BigInteger>> GetArrayOfUint256QueryAsync(GetArrayOfUint256Function getArrayOfUint256Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetArrayOfUint256Function, List<BigInteger>>(getArrayOfUint256Function, blockParameter);
        }

        
        public Task<List<BigInteger>> GetArrayOfUint256QueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetArrayOfUint256Function, List<BigInteger>>(null, blockParameter);
        }

        public Task<bool> GetBoolValueQueryAsync(GetBoolValueFunction getBoolValueFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetBoolValueFunction, bool>(getBoolValueFunction, blockParameter);
        }

        
        public Task<bool> GetBoolValueQueryAsync(bool @bool, BlockParameter blockParameter = null)
        {
            var getBoolValueFunction = new GetBoolValueFunction();
                getBoolValueFunction.Bool = @bool;
            
            return ContractHandler.QueryAsync<GetBoolValueFunction, bool>(getBoolValueFunction, blockParameter);
        }

        public Task<byte[]> GetBytes32AsResponseQueryAsync(GetBytes32AsResponseFunction getBytes32AsResponseFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetBytes32AsResponseFunction, byte[]>(getBytes32AsResponseFunction, blockParameter);
        }

        
        public Task<byte[]> GetBytes32AsResponseQueryAsync(byte[] request, BlockParameter blockParameter = null)
        {
            var getBytes32AsResponseFunction = new GetBytes32AsResponseFunction();
                getBytes32AsResponseFunction.Request = request;
            
            return ContractHandler.QueryAsync<GetBytes32AsResponseFunction, byte[]>(getBytes32AsResponseFunction, blockParameter);
        }

        public Task<BigInteger> GetEthAmountOfOwnerQueryAsync(GetEthAmountOfOwnerFunction getEthAmountOfOwnerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetEthAmountOfOwnerFunction, BigInteger>(getEthAmountOfOwnerFunction, blockParameter);
        }

        
        public Task<BigInteger> GetEthAmountOfOwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetEthAmountOfOwnerFunction, BigInteger>(null, blockParameter);
        }

        public Task<GetMultipleResponsesOutputDTO> GetMultipleResponsesQueryAsync(GetMultipleResponsesFunction getMultipleResponsesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetMultipleResponsesFunction, GetMultipleResponsesOutputDTO>(getMultipleResponsesFunction, blockParameter);
        }

        public Task<GetMultipleResponsesOutputDTO> GetMultipleResponsesQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetMultipleResponsesFunction, GetMultipleResponsesOutputDTO>(null, blockParameter);
        }

        public Task<string> GetOwnerQueryAsync(GetOwnerFunction getOwnerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetOwnerFunction, string>(getOwnerFunction, blockParameter);
        }

        
        public Task<string> GetOwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetOwnerFunction, string>(null, blockParameter);
        }

        public Task<string> GetStringAsResponseQueryAsync(GetStringAsResponseFunction getStringAsResponseFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetStringAsResponseFunction, string>(getStringAsResponseFunction, blockParameter);
        }

        
        public Task<string> GetStringAsResponseQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetStringAsResponseFunction, string>(null, blockParameter);
        }

        public Task<GetStructOutputDTO> GetStructQueryAsync(GetStructFunction getStructFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetStructFunction, GetStructOutputDTO>(getStructFunction, blockParameter);
        }

        public Task<GetStructOutputDTO> GetStructQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetStructFunction, GetStructOutputDTO>(null, blockParameter);
        }

        public Task<GetStructAsParameterOutputDTO> GetStructAsParameterQueryAsync(GetStructAsParameterFunction getStructAsParameterFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetStructAsParameterFunction, GetStructAsParameterOutputDTO>(getStructAsParameterFunction, blockParameter);
        }

        public Task<GetStructAsParameterOutputDTO> GetStructAsParameterQueryAsync(TestStruct @struct, BlockParameter blockParameter = null)
        {
            var getStructAsParameterFunction = new GetStructAsParameterFunction();
                getStructAsParameterFunction.Struct = @struct;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetStructAsParameterFunction, GetStructAsParameterOutputDTO>(getStructAsParameterFunction, blockParameter);
        }

        public Task<string> IncrementCounterRequestAsync(IncrementCounterFunction incrementCounterFunction)
        {
             return ContractHandler.SendRequestAsync(incrementCounterFunction);
        }

        public Task<string> IncrementCounterRequestAsync()
        {
             return ContractHandler.SendRequestAsync<IncrementCounterFunction>();
        }

        public Task<TransactionReceipt> IncrementCounterRequestAndWaitForReceiptAsync(IncrementCounterFunction incrementCounterFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(incrementCounterFunction, cancellationToken);
        }

        public Task<TransactionReceipt> IncrementCounterRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<IncrementCounterFunction>(null, cancellationToken);
        }

        public Task<byte[]> ReturnKeccak256QueryAsync(ReturnKeccak256Function returnKeccak256Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ReturnKeccak256Function, byte[]>(returnKeccak256Function, blockParameter);
        }

        
        public Task<byte[]> ReturnKeccak256QueryAsync(string input, BlockParameter blockParameter = null)
        {
            var returnKeccak256Function = new ReturnKeccak256Function();
                returnKeccak256Function.Input = input;
            
            return ContractHandler.QueryAsync<ReturnKeccak256Function, byte[]>(returnKeccak256Function, blockParameter);
        }

        public Task<BigInteger> ReturnUintQueryAsync(ReturnUintFunction returnUintFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ReturnUintFunction, BigInteger>(returnUintFunction, blockParameter);
        }

        
        public Task<BigInteger> ReturnUintQueryAsync(BigInteger input128Uint, BlockParameter blockParameter = null)
        {
            var returnUintFunction = new ReturnUintFunction();
                returnUintFunction.Input128Uint = input128Uint;
            
            return ContractHandler.QueryAsync<ReturnUintFunction, BigInteger>(returnUintFunction, blockParameter);
        }

        public Task<BigInteger> ReturnUint256QueryAsync(ReturnUint256Function returnUint256Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ReturnUint256Function, BigInteger>(returnUint256Function, blockParameter);
        }

        
        public Task<BigInteger> ReturnUint256QueryAsync(BigInteger input, BlockParameter blockParameter = null)
        {
            var returnUint256Function = new ReturnUint256Function();
                returnUint256Function.Input = input;
            
            return ContractHandler.QueryAsync<ReturnUint256Function, BigInteger>(returnUint256Function, blockParameter);
        }

        public Task<string> TransferEtherToOwnerRequestAsync(TransferEtherToOwnerFunction transferEtherToOwnerFunction)
        {
             return ContractHandler.SendRequestAsync(transferEtherToOwnerFunction);
        }

        public Task<string> TransferEtherToOwnerRequestAsync()
        {
             return ContractHandler.SendRequestAsync<TransferEtherToOwnerFunction>();
        }

        public Task<TransactionReceipt> TransferEtherToOwnerRequestAndWaitForReceiptAsync(TransferEtherToOwnerFunction transferEtherToOwnerFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferEtherToOwnerFunction, cancellationToken);
        }

        public Task<TransactionReceipt> TransferEtherToOwnerRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<TransferEtherToOwnerFunction>(null, cancellationToken);
        }
    }
}
