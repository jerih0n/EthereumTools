using NBitcoin;
using Nethereum.Web3.Accounts;
using System.Text.RegularExpressions;

namespace EthereumStamrtContracts.Logic.Wallet
{
    public class HDWallet
    {
        private const string VALID_ADDRESS_REGEX = "^0x[a-fA-F0-9]{40}$";
        private int _addressIndex = 0;

        private readonly Nethereum.HdWallet.Wallet _wallet;

        public HDWallet(string mnemonic)
        {
            _wallet = new Nethereum.HdWallet.Wallet(mnemonic, "");
            var addresses = _wallet.GetAddresses();

            Addresses = addresses;
            FirstAddress = addresses[_addressIndex];
            Account = _wallet.GetAccount(_addressIndex);
        }

        public Account GetAccountForAddress(string address)
        {
            var addressIndex = Array.IndexOf(Addresses, address);
            _addressIndex = addressIndex;
            return _wallet.GetAccount(addressIndex);
        }

        public bool IsAddress(string address)
            => Regex.IsMatch(address, VALID_ADDRESS_REGEX);

        public string FirstAddress { get; }
        public Account Account { get; }
        public string[] Addresses { get; }

        public int AddressIndex
        { get { return _addressIndex; } }
    }
}