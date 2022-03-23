namespace EthereumStamrtContracts.Logic.Configuration.Models
{
    public class NetworkConfiguration
    {
        public string RPCUrl { get; set; } = string.Empty;
        public int Port { get; set; }
        public int NetworkId { get; set; }
        public string WebsocketUrl { get; set; } = string.Empty;
    }
}