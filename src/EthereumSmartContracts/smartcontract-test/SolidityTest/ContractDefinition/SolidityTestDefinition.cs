using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace SmartcontractTest.Contracts.SolidityTest.ContractDefinition
{


    public partial class SolidityTestDeployment : SolidityTestDeploymentBase
    {
        public SolidityTestDeployment() : base(BYTECODE) { }
        public SolidityTestDeployment(string byteCode) : base(byteCode) { }
    }

    public class SolidityTestDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801561001057600080fd5b50600080546001600160a01b0319163390811782556001805480820182558184527fb10e2d527612073b26eecdfd717e6a320cf44b4afac2b0732d9fcbe2b7fa0cf690810182905581548083018355600290820181905582548084019093556003929091019190915560408051606081018252928352678ac7230489e800006020808501919091528151908101949094529092828201910160408051808303601f1901815291815281516020928301209092528354600180820186556000958652828620855160039093020180546001600160a01b0319166001600160a01b039093169290921782558483015190820155928201516002938401558151606081018352338152678ac7230489e8000081830152825191820194909452919291828201910160408051808303601f1901815291815281516020928301209092528354600180820186556000958652828620855160039093020180546001600160a01b0319166001600160a01b039093169290921782558483015190820155928201516002909301929092558051606081018252338152678ac7230489e8000081840152815192830193909352828101910160408051808303601f1901815291815281516020928301209092528251600380546001600160a01b0319166001600160a01b039092169190911790558201516004550151600555610953806102166000396000f3fe6080604052600436106101085760003560e01c80635b34b966116100955780639e074abc116100645780639e074abc14610247578063a6ca2c8b146101b8578063af834d37146102fc578063b8af92861461033d578063c5a859b81461035d57600080fd5b80635b34b96614610282578063893d20e8146102995780639779cdeb146102c15780639850b5f6146102c957600080fd5b80633b693e30116100dc5780633b693e30146101da57806349ffb514146102085780634eeca0761461023157806359adb2df146102475780635a193a5d1461026257600080fd5b80623ce0521461010d578063067a3f941461014357806309b1b3f21461015857806319fbb993146101b8575b600080fd5b34801561011957600080fd5b5061012d61012836600461056a565b61039e565b60405161013a91906105df565b60405180910390f35b34801561014f57600080fd5b5061012d6103dd565b34801561016457600080fd5b5060408051606080820183526000808352602080840182905292840152825190810183526003546001600160a01b0316815260045491810191909152600554918101919091525b60405161013a9190610623565b3480156101c457600080fd5b506101cd610435565b60405161013a919061064d565b3480156101e657600080fd5b506101f86101f53660046106ac565b90565b604051901515815260200161013a565b34801561021457600080fd5b506000546001600160a01b0316315b60405190815260200161013a565b34801561023d57600080fd5b5061022360065481565b34801561025357600080fd5b506102236101f53660046106d5565b34801561026e57600080fd5b506101ab61027d3660046106ee565b6104b7565b34801561028e57600080fd5b506102976104e3565b005b3480156102a557600080fd5b506000546040516001600160a01b03909116815260200161013a565b6102976104fd565b3480156102d557600080fd5b506102e46101f5366004610706565b6040516001600160801b03909116815260200161013a565b34801561030857600080fd5b506040805180820182526012815271526573706f6e736520617320537472696e6760701b6020820152905161013a919061077c565b34801561034957600080fd5b506102236103583660046107a5565b61053a565b34801561036957600080fd5b50604080518082018252600b81526a5465737420537472696e6760a81b6020820152905161013a91620186a091339190610856565b60608282808060200260200160405190810160405280939291908181526020018383602002808284376000920191909152509293505050505b92915050565b6060600180548060200260200160405190810160405280929190818152602001828054801561042b57602002820191906000526020600020905b815481526020019060010190808311610417575b5050505050905090565b60606002805480602002602001604051908101604052809291908181526020016000905b828210156104ae576000848152602090819020604080516060810182526003860290920180546001600160a01b0316835260018082015484860152600290910154918301919091529083529092019101610459565b50505050905090565b60408051606081018252600080825260208201819052918101919091526103d736839003830183610889565b6001600660008282546104f691906108f7565b9091555050565b600080546040516001600160a01b03909116913480156108fc02929091818181858888f19350505050158015610537573d6000803e3d6000fd5b50565b60008160405160200161054d919061077c565b604051602081830303815290604052805190602001209050919050565b6000806020838503121561057d57600080fd5b823567ffffffffffffffff8082111561059557600080fd5b818501915085601f8301126105a957600080fd5b8135818111156105b857600080fd5b8660208260051b85010111156105cd57600080fd5b60209290920196919550909350505050565b6020808252825182820181905260009190848201906040850190845b81811015610617578351835292840192918401916001016105fb565b50909695505050505050565b81516001600160a01b031681526020808301519082015260408083015190820152606081016103d7565b6020808252825182820181905260009190848201906040850190845b818110156106175761069983855180516001600160a01b0316825260208082015190830152604090810151910152565b9284019260609290920191600101610669565b6000602082840312156106be57600080fd5b813580151581146106ce57600080fd5b9392505050565b6000602082840312156106e757600080fd5b5035919050565b60006060828403121561070057600080fd5b50919050565b60006020828403121561071857600080fd5b81356001600160801b03811681146106ce57600080fd5b6000815180845260005b8181101561075557602081850181015186830182015201610739565b81811115610767576000602083870101525b50601f01601f19169290920160200192915050565b6020815260006106ce602083018461072f565b634e487b7160e01b600052604160045260246000fd5b6000602082840312156107b757600080fd5b813567ffffffffffffffff808211156107cf57600080fd5b818401915084601f8301126107e357600080fd5b8135818111156107f5576107f561078f565b604051601f8201601f19908116603f0116810190838211818310171561081d5761081d61078f565b8160405282815287602084870101111561083657600080fd5b826020860160208301376000928101602001929092525095945050505050565b8381526001600160a01b03831660208201526060604082018190526000906108809083018461072f565b95945050505050565b60006060828403121561089b57600080fd5b6040516060810181811067ffffffffffffffff821117156108be576108be61078f565b60405282356001600160a01b03811681146108d857600080fd5b8152602083810135908201526040928301359281019290925250919050565b6000821982111561091857634e487b7160e01b600052601160045260246000fd5b50019056fea264697066735822122036ef3ba084ff9fa547807e9fe4f7d74234e1a81fc1caf8db3f939a67d8ba888164736f6c634300080d0033";
        public SolidityTestDeploymentBase() : base(BYTECODE) { }
        public SolidityTestDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class CounterFunction : CounterFunctionBase { }

    [Function("Counter", "uint256")]
    public class CounterFunctionBase : FunctionMessage
    {

    }

    public partial class GetArrayAsInputFunction : GetArrayAsInputFunctionBase { }

    [Function("getArrayAsInput", "uint256[]")]
    public class GetArrayAsInputFunctionBase : FunctionMessage
    {
        [Parameter("uint256[]", "_arrayInput", 1)]
        public virtual List<BigInteger> ArrayInput { get; set; }
    }

    public partial class GetArrayOfSctructsFunction : GetArrayOfSctructsFunctionBase { }

    [Function("getArrayOfSctructs", typeof(GetArrayOfSctructsOutputDTO))]
    public class GetArrayOfSctructsFunctionBase : FunctionMessage
    {

    }

    public partial class GetArrayOfStructsFunction : GetArrayOfStructsFunctionBase { }

    [Function("getArrayOfStructs", typeof(GetArrayOfStructsOutputDTO))]
    public class GetArrayOfStructsFunctionBase : FunctionMessage
    {

    }

    public partial class GetArrayOfUint256Function : GetArrayOfUint256FunctionBase { }

    [Function("getArrayOfUint256", "uint256[]")]
    public class GetArrayOfUint256FunctionBase : FunctionMessage
    {

    }

    public partial class GetBoolValueFunction : GetBoolValueFunctionBase { }

    [Function("getBoolValue", "bool")]
    public class GetBoolValueFunctionBase : FunctionMessage
    {
        [Parameter("bool", "_bool", 1)]
        public virtual bool Bool { get; set; }
    }

    public partial class GetBytes32AsResponseFunction : GetBytes32AsResponseFunctionBase { }

    [Function("getBytes32AsResponse", "bytes32")]
    public class GetBytes32AsResponseFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "_request", 1)]
        public virtual byte[] Request { get; set; }
    }

    public partial class GetEthAmountOfOwnerFunction : GetEthAmountOfOwnerFunctionBase { }

    [Function("getEthAmountOfOwner", "uint256")]
    public class GetEthAmountOfOwnerFunctionBase : FunctionMessage
    {

    }

    public partial class GetMultipleResponsesFunction : GetMultipleResponsesFunctionBase { }

    [Function("getMultipleResponses", typeof(GetMultipleResponsesOutputDTO))]
    public class GetMultipleResponsesFunctionBase : FunctionMessage
    {

    }

    public partial class GetOwnerFunction : GetOwnerFunctionBase { }

    [Function("getOwner", "address")]
    public class GetOwnerFunctionBase : FunctionMessage
    {

    }

    public partial class GetStringAsResponseFunction : GetStringAsResponseFunctionBase { }

    [Function("getStringAsResponse", "string")]
    public class GetStringAsResponseFunctionBase : FunctionMessage
    {

    }

    public partial class GetStructFunction : GetStructFunctionBase { }

    [Function("getStruct", typeof(GetStructOutputDTO))]
    public class GetStructFunctionBase : FunctionMessage
    {

    }

    public partial class GetStructAsParameterFunction : GetStructAsParameterFunctionBase { }

    [Function("getStructAsParameter", typeof(GetStructAsParameterOutputDTO))]
    public class GetStructAsParameterFunctionBase : FunctionMessage
    {
        [Parameter("tuple", "_struct", 1)]
        public virtual TestStruct Struct { get; set; }
    }

    public partial class IncrementCounterFunction : IncrementCounterFunctionBase { }

    [Function("incrementCounter")]
    public class IncrementCounterFunctionBase : FunctionMessage
    {

    }

    public partial class ReturnKeccak256Function : ReturnKeccak256FunctionBase { }

    [Function("returnKeccak256", "bytes32")]
    public class ReturnKeccak256FunctionBase : FunctionMessage
    {
        [Parameter("string", "input", 1)]
        public virtual string Input { get; set; }
    }

    public partial class ReturnUintFunction : ReturnUintFunctionBase { }

    [Function("returnUint", "uint128")]
    public class ReturnUintFunctionBase : FunctionMessage
    {
        [Parameter("uint128", "_input128Uint", 1)]
        public virtual BigInteger Input128Uint { get; set; }
    }

    public partial class ReturnUint256Function : ReturnUint256FunctionBase { }

    [Function("returnUint256", "uint256")]
    public class ReturnUint256FunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_input", 1)]
        public virtual BigInteger Input { get; set; }
    }

    public partial class TransferEtherToOwnerFunction : TransferEtherToOwnerFunctionBase { }

    [Function("transferEtherToOwner")]
    public class TransferEtherToOwnerFunctionBase : FunctionMessage
    {

    }

    public partial class CounterOutputDTO : CounterOutputDTOBase { }

    [FunctionOutput]
    public class CounterOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetArrayAsInputOutputDTO : GetArrayAsInputOutputDTOBase { }

    [FunctionOutput]
    public class GetArrayAsInputOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256[]", "_arrayResponse", 1)]
        public virtual List<BigInteger> ArrayResponse { get; set; }
    }

    public partial class GetArrayOfSctructsOutputDTO : GetArrayOfSctructsOutputDTOBase { }

    [FunctionOutput]
    public class GetArrayOfSctructsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple[]", "_structResponse", 1)]
        public virtual List<TestStruct> StructResponse { get; set; }
    }

    public partial class GetArrayOfStructsOutputDTO : GetArrayOfStructsOutputDTOBase { }

    [FunctionOutput]
    public class GetArrayOfStructsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple[]", "_arrayOfStructs", 1)]
        public virtual List<TestStruct> ArrayOfStructs { get; set; }
    }

    public partial class GetArrayOfUint256OutputDTO : GetArrayOfUint256OutputDTOBase { }

    [FunctionOutput]
    public class GetArrayOfUint256OutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256[]", "_arrayOfUint256", 1)]
        public virtual List<BigInteger> ArrayOfUint256 { get; set; }
    }

    public partial class GetBoolValueOutputDTO : GetBoolValueOutputDTOBase { }

    [FunctionOutput]
    public class GetBoolValueOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class GetBytes32AsResponseOutputDTO : GetBytes32AsResponseOutputDTOBase { }

    [FunctionOutput]
    public class GetBytes32AsResponseOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "response", 1)]
        public virtual byte[] Response { get; set; }
    }

    public partial class GetEthAmountOfOwnerOutputDTO : GetEthAmountOfOwnerOutputDTOBase { }

    [FunctionOutput]
    public class GetEthAmountOfOwnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetMultipleResponsesOutputDTO : GetMultipleResponsesOutputDTOBase { }

    [FunctionOutput]
    public class GetMultipleResponsesOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
        [Parameter("address", "", 2)]
        public virtual string ReturnValue2 { get; set; }
        [Parameter("string", "", 3)]
        public virtual string ReturnValue3 { get; set; }
    }

    public partial class GetOwnerOutputDTO : GetOwnerOutputDTOBase { }

    [FunctionOutput]
    public class GetOwnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class GetStringAsResponseOutputDTO : GetStringAsResponseOutputDTOBase { }

    [FunctionOutput]
    public class GetStringAsResponseOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class GetStructOutputDTO : GetStructOutputDTOBase { }

    [FunctionOutput]
    public class GetStructOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "testStruct", 1)]
        public virtual TestStruct TestStruct { get; set; }
    }

    public partial class GetStructAsParameterOutputDTO : GetStructAsParameterOutputDTOBase { }

    [FunctionOutput]
    public class GetStructAsParameterOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "_structResponse", 1)]
        public virtual TestStruct StructResponse { get; set; }
    }



    public partial class ReturnKeccak256OutputDTO : ReturnKeccak256OutputDTOBase { }

    [FunctionOutput]
    public class ReturnKeccak256OutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class ReturnUintOutputDTO : ReturnUintOutputDTOBase { }

    [FunctionOutput]
    public class ReturnUintOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint128", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class ReturnUint256OutputDTO : ReturnUint256OutputDTOBase { }

    [FunctionOutput]
    public class ReturnUint256OutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }


}
