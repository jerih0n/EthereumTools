using Newtonsoft.Json;

namespace EthereumSmartContracts.App.SmartcontractDb.Service
{
    public class SmartContractDbService
    {
        private const string SAMRT_CONTRACTS_LOCAL_FILE = "smartcontracts.json";
        private SmartContractsDbModel _db;

        public SmartContractDbService()
        {
            Validate();
            _db = LoadDb();
        }

        public void AddNewSmartContract(SmartContractModel smartContractModel)
        {
            _db.SmartContracts.Add(smartContractModel);
            SaveChanges();
        }

        private void Validate()
        {
            if (!File.Exists(SAMRT_CONTRACTS_LOCAL_FILE))
            {
                InitializeNewDb();
            }
        }

        private void InitializeNewDb()
        {
            var newDb = new SmartContractsDbModel();
            var dbAsJson = JsonConvert.SerializeObject(newDb);

            using (var sr = new StreamWriter(SAMRT_CONTRACTS_LOCAL_FILE))
            {
                sr.WriteLine(dbAsJson);
            }
        }

        private void SaveChanges()
        {
            using (var writter = new StreamWriter(SAMRT_CONTRACTS_LOCAL_FILE))
            {
                var db = JsonConvert.SerializeObject(_db);
                writter.WriteLine(db);
            }
        }

        private SmartContractsDbModel LoadDb()
        {
            using (var reader = new StreamReader(SAMRT_CONTRACTS_LOCAL_FILE))
            {
                var db = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<SmartContractsDbModel>(db);
            }
        }

        public SmartContractsDbModel Data
        { get { return _db; } }
    }
}