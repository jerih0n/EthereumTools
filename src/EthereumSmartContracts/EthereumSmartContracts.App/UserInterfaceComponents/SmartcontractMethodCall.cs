using EthereumStamrtContracts.Logic.Blockchain;
using EthereumStamrtContracts.Logic.SmartContracts;
using EthereumStamrtContracts.Logic.Utils;
using Newtonsoft.Json;
using System.Linq;
using System.Text;

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
        private bool _triggersTransaction = false;
        private readonly dynamic _fullContractAbi;
        private readonly string _address;
        private readonly BlockchainConnector _blockchainConnector;
        private readonly AbiObject<AbiOuthputs> _abiInputs;

        public SmartcontractMethodCall(dynamic abi, dynamic fullContractAbi, string address, BlockchainConnector blockchainConnector)
        {
            InitializeComponent();
            _fullContractAbi = fullContractAbi;
            _address = address;
            _blockchainConnector = blockchainConnector;
            Name = Guid.NewGuid().ToString();
            this.result.Text = string.Empty;
            _abiInputs = JsonConvert.DeserializeObject<AbiObject<AbiOuthputs>>(JsonConvert.SerializeObject(abi));
            Initialize();
        }

        public bool ShouldDisplay
        { get { return _shouldDisplay; } }

        private async void callFunctionBtn_Click(object sender, EventArgs e)
        {
            if (!_triggersTransaction)
            {
                //TODO
                this.result.Text = "Processing...";
                var result = await _blockchainConnector.CallNonTransactionResultingFunction(JsonConvert.SerializeObject(_fullContractAbi), _address, this.callFunctionBtn.Text, null);
                var resultAsJson = JsonConvert.SerializeObject(result);
                this.result.Text = resultAsJson;
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
                    InitializeViewAndPureFunction();
                    break;

                case PURE:
                    InitializeViewAndPureFunction();
                    break;

                case NONPAYABLE:
                    InitializePayableAndNonPayableFunction(NON_PAYABLE_FUNCTION_COLOR);
                    break;
            }
        }

        private void InitializeViewAndPureFunction()
        {
            this.callFunctionBtn.Text = _abiInputs.Name;
            this.callFunctionBtn.BackColor = Color.Green;
            CreateInput();
        }

        private void InitializePayableAndNonPayableFunction(Color color)
        {
            this.callFunctionBtn.Text = _abiInputs.Name;
            this.callFunctionBtn.BackColor = color;
            _triggersTransaction = true;
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
                parameters.Add($"{input.Type} {input.Name}");
            }
            this.parameterInputsTxtBox.PlaceholderText = String.Join(", ", parameters);
        }

        //TODO:
        //MAP INPUTS!
    }
}