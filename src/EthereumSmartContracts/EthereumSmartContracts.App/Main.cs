using EthereumSmartContracts.App.Configuration;
using EthereumStamrtContracts.Logic.Blockchain;
using EthereumStamrtContracts.Logic.Wallet;
using Nethereum.Web3.Accounts;
using EthereumStamrtContracts.Logic.Extensions;
using EthereumSmartContracts.App.SmartcontractDb.Service;
using EthereumSmartContracts.App.UserInterfaceComponents;

namespace EthereumSmartContracts.App
{
    public partial class Main : Form
    {
        private readonly HDWallet _hdWallet;
        private readonly BlockchainConnector _blockchainConnector;
        private string _selectedAddress = string.Empty;
        private string _ethBalancePattern = "Balance: {0} ETH";
        private Account _account;
        private string _newSmartContractBuildJson = string.Empty;
        private readonly SmartContractDbService _smartContractDbService;

        public Main()
        {
            InitializeComponent();
            this.ethBalance.Text = string.Empty;
            var mnemonic = AppConfigurationManager.GetMnemonic();
            this.mnemonicPhrase.Text = $"{mnemonic}";
            var networkConfiguration = AppConfigurationManager.GetNetworkConfiguration();
            _hdWallet = new HDWallet(mnemonic);
            _account = _hdWallet.Account;
            _blockchainConnector = new BlockchainConnector(networkConfiguration, _account);
            _smartContractDbService = new SmartContractDbService();

            for (int i = 0; i < _hdWallet.Addresses.Length; i++)
            {
                this.addressesComboBox.Items.Add(_hdWallet.Addresses[i]);
                if (i == 0)
                {
                    this.addressesComboBox.SelectedIndex = 0;
                }
            }

            InitializeDataGrid();
        }

        private async void addressesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var currentIndex = this.addressesComboBox.SelectedIndex;
            _selectedAddress = _hdWallet.Addresses[currentIndex];
            _account = _hdWallet.GetAccountForAddress(_selectedAddress);
            _blockchainConnector.UseAccount(_account);
            var ethBalance = await _blockchainConnector.GetEthBalance(_account.Address);
            this.ethBalance.Text = string.Format(_ethBalancePattern, ethBalance.NormalizeToDefaultDecimal().ToString());
        }

        private void uploadABIBtn_Click(object sender, EventArgs e)
        {
            _newSmartContractBuildJson = null;
            string filePath = string.Empty;
            string fileContent = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = AppConfigurationManager.GetSmartcontractDirectory();
                openFileDialog.Filter = "json files (*.json)|*.json";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }

                    _newSmartContractBuildJson = fileContent;
                }
            }
        }

        private void addNewContractBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_newSmartContractBuildJson))
            {
                var address = this.contractAddress.Text;
                if (_hdWallet.IsAddress(address))
                {
                    _smartContractDbService.AddNewSmartContract(_newSmartContractBuildJson, address);
                    InitializeDataGrid();
                    return;
                }
                MessageBox.Show("Invalid Address");
            }
            else
            {
                MessageBox.Show("Contract ABI and Address are mandatory!");
            }
        }

        private void InitializeDataGrid()
        {
            this.smartContractsGrid.Rows.Clear();
            foreach (var smartContract in _smartContractDbService.Data.SmartContracts)
            {
                this.smartContractsGrid.Rows.Add(smartContract.ContractName, smartContract.ContractAddress, "Select", "Delete");
            }
        }

        private void smartContractsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.smartcontracMethodsPanel.Controls.Clear();

            try
            {
                var rowId = e.RowIndex;

                var selectedSmartContract = _smartContractDbService.Data.SmartContracts[rowId];

                foreach (var abiObj in selectedSmartContract.Abi)
                {
                    var functionCall = new SmartcontractMethodCall(abiObj,
                        selectedSmartContract.Abi,
                        selectedSmartContract.ContractAddress,
                        _blockchainConnector,
                        this.transactionResultTextbox);

                    if (functionCall.ShouldDisplay)
                    {
                        this.smartcontracMethodsPanel.Controls.Add(functionCall);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteConractsBtn_Click(object sender, EventArgs e)
        {
            _smartContractDbService.DeleteAll();
            InitializeDataGrid();
        }
    }
}