using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace SmartcontractTest.Contracts.SolidityTest.ContractDefinition
{
    public partial class TestStruct : TestStructBase { }

    public class TestStructBase 
    {
        [Parameter("address", "_address", 1)]
        public virtual string Address { get; set; }
        [Parameter("uint256", "_number", 2)]
        public virtual BigInteger Number { get; set; }
        [Parameter("bytes32", "_id", 3)]
        public virtual byte[] Id { get; set; }
    }
}
