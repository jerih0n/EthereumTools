using EthereumStamrtContracts.Logic.Configuration.Models;
using Microsoft.Extensions.Configuration;

namespace EthereumSmartContracts.App.Configuration
{
    public static class AppConfigurationManager
    {
        public static string GetMnemonic()
            => Program.Configuration.GetSection("Mnemonic").Get<string>();

        public static NetworkConfiguration GetNetworkConfiguration()
            => Program.Configuration.GetSection("Network").Get<NetworkConfiguration>();

        public static string GetSmartcontractDirectory()
            => Program.Configuration.GetSection("SmartContractsPath").Get<string>();
    }
}