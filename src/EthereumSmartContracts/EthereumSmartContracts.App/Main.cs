using EthereumSmartContracts.App.Configuration;
using EthereumStamrtContracts.Logic.Blockchain;
using EthereumStamrtContracts.Logic.Wallet;
using Nethereum.Web3.Accounts;
using EthereumStamrtContracts.Logic.Extensions;

namespace EthereumSmartContracts.App
{
    public partial class Main : Form
    {
        private readonly HDWallet _hdWallet;
        private readonly BlockchainConnector _blockchainConnector;
        private string _selectedAddress = string.Empty;
        private string _ethBalancePattern = "Balance: {0} ETH";
        private Account _account;

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

            foreach (var address in _hdWallet.Addresses)
            {
                this.addressesComboBox.Items.Add(address);
            }
        }

        private async void addressesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var currentIndex = this.addressesComboBox.SelectedIndex;
            _selectedAddress = _hdWallet.Addresses[currentIndex];
            _account = _hdWallet.GetAccountForAddress(_selectedAddress);
            var ethBalance = await _blockchainConnector.GetEthBalance(_account.Address);
            this.ethBalance.Text = string.Format(_ethBalancePattern, ethBalance.NormalizeToDefaultDecimal().ToString());
        }
    }
}