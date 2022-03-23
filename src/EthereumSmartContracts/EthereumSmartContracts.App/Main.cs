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
        private readonly Account _account;
        private readonly BlockchainConnector _blockchainConnector;

        public Main()
        {
            InitializeComponent();
            var mnemonic = AppConfigurationManager.GetMnemonic();
            this.mnemonicPhrase.Text = $"{mnemonic}";
            var networkConfiguration = AppConfigurationManager.GetNetworkConfiguration();
            _hdWallet = new HDWallet(mnemonic);
            _account = _hdWallet.Account;
            _blockchainConnector = new BlockchainConnector(networkConfiguration, _account);
            this.ethereumAddress.Text = _hdWallet.FirstAddress;
        }

        private void mnemonicImportButton_Click(object sender, EventArgs e)
        {
        }
    }
}