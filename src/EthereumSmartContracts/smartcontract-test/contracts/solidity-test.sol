pragma solidity ^0.8.0;

contract SolidityTest {
    address payable private _owner;
    uint256[] private _arrayWithUint256;

    TestStruct[] private _testStructArray;

    struct TestStruct {
        address _address;
        uint256 _number;
        bytes32 _id;
    }

    constructor() {
        _owner = payable(msg.sender);
        _arrayWithUint256.push(1);
        _arrayWithUint256.push(2);
        _arrayWithUint256.push(3);
        _testStructArray.push(
            TestStruct(
                msg.sender,
                10 * 10**18,
                keccak256(abi.encode(address(0)))
            )
        );
        _testStructArray.push(
            TestStruct(
                msg.sender,
                10 * 10**18,
                keccak256(abi.encode(address(0)))
            )
        );
    }

    uint256 public Counter;

    function getOwner() public view returns (address) {
        return _owner;
    }

    function returnUint256(uint256 _input) public pure returns (uint256) {
        return _input;
    }

    function returnUint(uint128 _input128Uint) public pure returns (uint128) {
        return _input128Uint;
    }

    function transferEtherToOwner() public payable {
        _owner.transfer(msg.value);
    }

    function getEthAmountOfOwner() public view returns (uint256) {
        return address(_owner).balance;
    }

    function returnKeccak256(string memory input)
        public
        pure
        returns (bytes32)
    {
        return keccak256(abi.encode(input));
    }

    function incrementCounter() public {
        Counter += 1;
    }

    function getBoolValue(bool _bool) public pure returns (bool) {
        return _bool;
    }

    function getArrayOfUint256()
        public
        view
        returns (uint256[] memory _arrayOfUint256)
    {
        return _arrayWithUint256;
    }

    function getArrayOfStructs()
        public
        view
        returns (TestStruct[] memory _arrayOfStructs)
    {
        return _testStructArray;
    }

    function gerArrayAsInput(uint256[] calldata _arrayInput)
        public
        pure
        returns (uint256[] memory _arrayResponse)
    {
        return _arrayInput;
    }

    function getStructAsParameter(TestStruct calldata _struct)
        public
        pure
        returns (TestStruct memory _structResponse)
    {
        return _struct;
    }

    function getArrayOfSctructs()
        public
        view
        returns (TestStruct[] memory _structResponse)
    {
        return _testStructArray;
    }

    function getStringAsRespone() public pure returns (string memory) {
        return "Response as String";
    }

    function getBytes32AsResponse(bytes32 _request)
        public
        pure
        returns (bytes32 response)
    {
        return _request;
    }
}
