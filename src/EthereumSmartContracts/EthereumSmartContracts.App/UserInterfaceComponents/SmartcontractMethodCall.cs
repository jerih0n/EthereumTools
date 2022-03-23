using EthereumStamrtContracts.Logic.Blockchain;
using EthereumStamrtContracts.Logic.SmartContracts;
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

        private readonly AbiObject _abiObject;
        private bool _shouldDisplay = false;
        private bool _triggersTransaction = false;
        private readonly string _fullContractAbi;
        private readonly string _address;
        private readonly BlockchainConnector _blockchainConnector;

        public SmartcontractMethodCall(AbiObject abiObject, string fullContractAbi, string address, BlockchainConnector blockchainConnector)
        {
            InitializeComponent();
            _fullContractAbi = fullContractAbi;
            _address = address;
            _abiObject = abiObject;
            _blockchainConnector = blockchainConnector;
            Initialize();
            Name = Guid.NewGuid().ToString();
            this.result.Text = String.Empty;
        }

        public bool ShouldDisplay
        { get { return _shouldDisplay; } }

        private async void callFunctionBtn_Click(object sender, EventArgs e)
        {
            if (!_triggersTransaction)
            {
                //TODO
                var result = _blockchainConnector.CallNonTransactionResultingFunction(_fullContractAbi, _address, this.callFunctionBtn.Text, null);
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
            this.callFunctionBtn.Text = _abiObject.Name;
            this.callFunctionBtn.BackColor = Color.Green;
            CreateInput();
        }

        private void InitializePayableAndNonPayableFunction(Color color)
        {
            this.callFunctionBtn.Text = _abiObject.Name;
            this.callFunctionBtn.BackColor = color;
            _triggersTransaction = true;
            CreateInput();
        }

        private void CreateInput()
        {
            if (_abiObject.Inputs == null || _abiObject.Inputs.Count == 0)
            {
                this.parameterInputsTxtBox.Visible = false;
                this.parameterInputsTxtBox.Enabled = false;
                return;
            }
            var parameters = new List<string>();
            foreach (var input in _abiObject.Inputs)
            {
                parameters.Add($"{input.Type} {input.Name}");
            }
            this.parameterInputsTxtBox.PlaceholderText = String.Join(", ", parameters);
        }

        //TODO:
        //MAP INPUTS!
    }
}