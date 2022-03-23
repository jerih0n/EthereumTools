using NBitcoin;
using Nethereum.Web3.Accounts;
using Nethereum.HdWallet;

namespace EthereumStamrtContracts.Logic.Wallet
{
    public class HDWallet
    {
        public HDWallet(string mnemonic)
        {
            Mnemonic mnemo = new Mnemonic(mnemonic);
            var privateKey = mnemo.DeriveExtKey().PrivateKey;
            var wallet = new Nethereum.HdWallet.Wallet(mnemonic, "");
            var address = wallet.GetAddresses()[0];
        }

        public string FirstAddress { get; }
        public Account Account { get; }
    }
}