using Nethereum.RPC.Eth.DTOs;

namespace EthereumStamrtContracts.Logic.Blockchain
{
    public class TransactionInformationModel
    {
        private readonly TransactionReceipt _transactionInformationModel;

        public TransactionInformationModel(TransactionReceipt transactionInformationModel)
        {
            _transactionInformationModel = transactionInformationModel;
            TransactionHash = transactionInformationModel.TransactionHash;
            TransactionHash = _transactionInformationModel.TransactionHash;
            TransactionIndex = _transactionInformationModel.TransactionIndex.ToString();
            BlockHash = transactionInformationModel.BlockHash;
            BlockNumber = transactionInformationModel.BlockNumber.ToString();
            GassUsed = transactionInformationModel.GasUsed.ToString();
            ContractAddress = transactionInformationModel.ContractAddress;
            Logs = transactionInformationModel.Logs;
        }

        public string TransactionHash { get; }
        public string TransactionIndex { get; }
        public string BlockHash { get; }
        public string BlockNumber { get; }
        public string GassUsed { get; }
        public string ContractAddress { get; }

        public object Logs { get; }
    }
}