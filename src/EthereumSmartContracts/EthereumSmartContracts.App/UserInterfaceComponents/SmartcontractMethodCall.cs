using EthereumStamrtContracts.Logic.Blockchain;
using EthereumStamrtContracts.Logic.SmartContracts;
using EthereumStamrtContracts.Logic.Utils;
using Nethereum.RPC.Eth.DTOs;
using Newtonsoft.Json;

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
        private const string PAYABLE = "payeble";

        #endregion StateMutabilityContant

        #endregion Constants

        private bool _shouldDisplay = false;
        private FunctionTypesEnum _functionType;
        private readonly dynamic _fullContractAbi;
        private readonly string _address;
        private readonly BlockchainConnector _blockchainConnector;
        private readonly AbiObject<AbiOuthputs> _abiInputs;
        private readonly List<string> _inputParametersTypes;
        private TextBox _transactionResponseTextBox;

        public SmartcontractMethodCall(dynamic abi, dynamic fullContractAbi, string address, BlockchainConnector blockchainConnector, TextBox transactionResponseTextBox)
        {
            InitializeComponent();
            _fullContractAbi = fullContractAbi;
            _address = address;
            _blockchainConnector = blockchainConnector;
            Name = Guid.NewGuid().ToString();
            this.result.Text = string.Empty;
            _abiInputs = JsonConvert.DeserializeObject<AbiObject<AbiOuthputs>>(JsonConvert.SerializeObject(abi));
            _inputParametersTypes = new List<string>();
            _transactionResponseTextBox = transactionResponseTextBox;
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

                var result = await _blockchainConnector.CallSmartcontractFunction(
                    JsonConvert.SerializeObject(_fullContractAbi),
                    _address, this.callFunctionBtn.Text,
                    _functionType,
                    inputParametes);

                if (_functionType != FunctionTypesEnum.ViewAndPure)
                {
                    ExtractTransactionOutput(result);
                    this.result.Text = "Success!";
                    return;
                }
                var resultAsJson = JsonConvert.SerializeObject(result);
                this.result.Text = resultAsJson;
            }
            catch (Exception ex)
            {
                this.result.Text = $"Finished with Error: {ex.Message}";
            }
        }

        private void Initialize()
        {
            switch (_abiInputs.Type)
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
            switch (_abiInputs.StateMutability)
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
                    InitializePayableAndNonPayableFunction(NON_PAYABLE_FUNCTION_COLOR);
                    break;
            }
        }

        private void InitializeViewAndPureFunction()
        {
            this.callFunctionBtn.Text = _abiInputs.Name;
            this.callFunctionBtn.BackColor = Color.SeaGreen;
            this.callFunctionBtn.ForeColor = Color.White;
            CreateInput();
        }

        private void InitializePayableAndNonPayableFunction(Color color)
        {
            this.callFunctionBtn.Text = _abiInputs.Name;
            this.callFunctionBtn.BackColor = color;
            CreateInput();
        }

        private void CreateInput()
        {
            if (_abiInputs == null || _abiInputs.Inputs.Count == 0)
            {
                this.parameterInputsTxtBox.Visible = false;
                this.parameterInputsTxtBox.Enabled = false;
                return;
            }
            var parameters = new List<string>();
            foreach (var input in _abiInputs.Inputs)
            {
                _inputParametersTypes.Add(input.Type);
                parameters.Add($"{input.Type} {input.Name}");
            }
            this.parameterInputsTxtBox.PlaceholderText = String.Join(", ", parameters);
        }

        public object[] CreateFunctionInput()
        {
            if (!_inputParametersTypes.Any())
            {
                return null;
            }
            var parameters = new object[_inputParametersTypes.Count];
            var inputedParameters = this.parameterInputsTxtBox.Text.Split(",", StringSplitOptions.RemoveEmptyEntries);
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

        private void ExtractTransactionOutput(object result)
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
    }
}