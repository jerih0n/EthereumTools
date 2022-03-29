using EthereumStamrtContracts.Logic.Blockchain;
using EthereumStamrtContracts.Logic.SmartContracts;
using EthereumStamrtContracts.Logic.Utils;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Newtonsoft.Json;
using System.Numerics;

namespace EthereumSmartContracts.App.UserInterfaceComponents
{
    public partial class SmartcontractMethodCall : UserControl
    {
        #region Constants

        #region Function Collors

        private readonly Color PAYABLE_FUNCTION_COLOR = Color.Red;
        private readonly Color NON_PAYABLE_FUNCTION_COLOR = Color.Orange;

        #endregion Function Collors

        #region AbiObjectType

        private const string CONSTRUCTOR = "constructor";
        private const string EVENT = "event";
        private const string FUNCTION = "function";

        #endregion AbiObjectType

        #region StateMutabilityContant

        private const string VIEW = "view";
        private const string NONPAYABLE = "nonpayable";
        private const string PURE = "pure";
        private const string PAYABLE = "payable";

        #endregion StateMutabilityContant

        private const int MAX_STRING_LENGHT_FOR_LABLE_OUTPUT = 60;

        #endregion Constants

        private bool _shouldDisplay = false;
        private FunctionTypesEnum _functionType;
        private readonly dynamic _fullContractAbi;
        private readonly string _address;
        private readonly BlockchainConnector _blockchainConnector;
        private readonly AbiObject<AbiFields> _abiObject;
        private readonly AbiObject<AbiFieldsWithComponents> _abiInputssWithComponents;
        private readonly List<string> _inputParametersTypes = new List<string>();
        private readonly bool _isMultipleOutputs;
        private HexBigInteger? _ethAmountToSend = null;
        private TextBox _transactionResponseTextBox;

        public SmartcontractMethodCall(dynamic abi, dynamic fullContractAbi, string address, BlockchainConnector blockchainConnector, TextBox transactionResponseTextBox)
        {
            InitializeComponent();
            _fullContractAbi = fullContractAbi;
            _address = address;
            _blockchainConnector = blockchainConnector;
            _transactionResponseTextBox = transactionResponseTextBox;
            Name = Guid.NewGuid().ToString();
            this.result.Text = string.Empty;
            var abiAsJson = JsonConvert.SerializeObject(abi);
            _abiInputssWithComponents = JsonConvert.DeserializeObject<AbiObject<AbiFieldsWithComponents>>(abiAsJson);
            if (_abiInputssWithComponents.Inputs.Any(x => x.Components != null && x.Components.Any()))
            {
                //TODO: handle structs as imputs
            }

            _abiObject = JsonConvert.DeserializeObject<AbiObject<AbiFields>>(abiAsJson);
            _isMultipleOutputs = ShouldExpectArrayAsOutput();
            Initialize();
        }

        public bool ShouldDisplay
        { get { return _shouldDisplay; } }

        private async void callFunctionBtn_Click(object sender, EventArgs e)
        {
            try
            {
                _transactionResponseTextBox.Text = string.Empty;
                this.result.Text = "Processing...";
                var inputParametes = CreateFunctionInput();
                if (_functionType == FunctionTypesEnum.Payable)
                {
                    var inputedParameters = GetInputedParameters();
                    if (inputedParameters.Length != 1)
                    {
                        throw new Exception("Invalid parameters. Should have only one input parameter");
                    }
                    _ethAmountToSend = new HexBigInteger(BigInteger.Parse(inputedParameters[0]));
                }
                var result = await _blockchainConnector.CallSmartcontractFunction(
                    JsonConvert.SerializeObject(_fullContractAbi),
                    _address, this.callFunctionBtn.Text,
                    _functionType,
                    _isMultipleOutputs,
                    _ethAmountToSend,
                    inputParametes);

                if (_functionType != FunctionTypesEnum.ViewAndPure)
                {
                    ExtractTransactionOutput(result);
                    this.result.Text = "Success!";
                    return;
                }
                var resultAsJson = (string)JsonConvert.SerializeObject(result, Formatting.Indented);
                if (resultAsJson.Length > MAX_STRING_LENGHT_FOR_LABLE_OUTPUT)
                {
                    this.result.Text = "Success!";
                    this._transactionResponseTextBox.Text = resultAsJson;
                    return;
                }
                this.result.Text = resultAsJson;
            }
            catch (Exception ex)
            {
                this.result.Text = $"Finished with Error: {ex.Message}";
            }
        }

        private void Initialize()
        {
            switch (_abiObject.Type)
            {
                case FUNCTION:
                    InitializeFunction();
                    break;

                default:
                    break;
            }
        }

        private void InitializeFunction()
        {
            _shouldDisplay = true;
            switch (_abiObject.StateMutability)
            {
                case VIEW:
                    _functionType = FunctionTypesEnum.ViewAndPure;
                    InitializeViewAndPureFunction();
                    break;

                case PURE:
                    _functionType = FunctionTypesEnum.ViewAndPure;
                    InitializeViewAndPureFunction();
                    break;

                case NONPAYABLE:
                    _functionType = FunctionTypesEnum.NonPayable;
                    InitializeNonPayableFunction();
                    break;

                case PAYABLE:
                    _functionType = FunctionTypesEnum.Payable;
                    InitializePayableFunction();
                    break;
            }
        }

        private void InitializeViewAndPureFunction()
        {
            this.callFunctionBtn.Text = _abiObject.Name;
            this.callFunctionBtn.BackColor = Color.SeaGreen;
            this.callFunctionBtn.ForeColor = Color.White;
            CreateInput();
        }

        private void InitializeNonPayableFunction()
        {
            this.callFunctionBtn.Text = _abiObject.Name;
            this.callFunctionBtn.BackColor = Color.Orange;
            CreateInput();
        }

        private void InitializePayableFunction()
        {
            this.callFunctionBtn.Text = _abiObject.Name;
            this.callFunctionBtn.BackColor = Color.DarkRed;
            this.callFunctionBtn.ForeColor = Color.White;

            this.parameterInputsTxtBox.Visible = true;
            this.parameterInputsTxtBox.Enabled = true;
            this.parameterInputsTxtBox.PlaceholderText = "value in wei";
        }

        private void CreateInput()
        {
            if (_abiObject == null || _abiObject.Inputs.Count == 0)
            {
                this.parameterInputsTxtBox.Visible = false;
                this.parameterInputsTxtBox.Enabled = false;
                return;
            }
            var parameters = new List<string>();
            foreach (var input in _abiObject.Inputs)
            {
                _inputParametersTypes.Add(input.Type);
                parameters.Add($"{input.Type} {input.Name}");
            }
            this.parameterInputsTxtBox.PlaceholderText = string.Join(", ", parameters);
        }

        public object[] CreateFunctionInput()
        {
            if (!_inputParametersTypes.Any())
            {
                return null;
            }
            var parameters = new object[_inputParametersTypes.Count];
            var inputedParameters = GetInputedParameters();
            if (inputedParameters.Length != parameters.Length)
            {
                throw new Exception("Invalid Parameters Inputed. Number of required parameters does not match with entered parameters");
            }
            for (int i = 0; i < parameters.Length; i++)
            {
                parameters[i] = EthrereumTypesConverterHelper.Convert(_inputParametersTypes[i], inputedParameters[i]);
            }
            return parameters;
        }

        private void ExtractTransactionOutput(dynamic result)
        {
            var transactionOutput = result as TransactionReceipt;
            if (transactionOutput == null)
            {
                return;
            }
            var transactionInformationModel = new TransactionInformationModel(transactionOutput);
            var transactionInfo = JsonConvert.SerializeObject(transactionInformationModel, Formatting.Indented);
            this._transactionResponseTextBox.Text = transactionInfo;
        }

        private bool ShouldExpectArrayAsOutput()
        {
            var outputs = _abiObject.Outputs;
            if (outputs.Count == 0) return false;
            if (_abiObject.Outputs.Count > 1)
            {
                return true;
            }
            if (outputs[0].Type.EndsWith("[]")) return true;

            return false;
        }

        private string[] GetInputedParameters()
        {
            var inputedParameters = this.parameterInputsTxtBox.Text.Split(",", StringSplitOptions.RemoveEmptyEntries);

            return inputedParameters;
        }
    }
}