using Admin.Picareta.Entidades;
using MongoDB.Driver;

namespace Admin.Picareta.Data.Context
{
    public class AdminMongoContext
    {
        private readonly IMongoDatabase _database;

        public AdminMongoContext(string user, string password, string connectTo, string dataBase, string port)
        {
            //TODO: fazer métodos na classe de mapeamento que converte as credenciais em conn string ou url
            // ai fica fácil de executar local ou no mlab
            //TODO: tratar exception em caso de banco não conectar
            var urlDataBase = $"mongodb://{user}:{password}{connectTo}.mlab.com:{port}/{dataBase}?retryWrites=false";
            MongoClient client = new MongoClient(urlDataBase);
            _database = client.GetDatabase(dataBase);
        }

        public IMongoCollection<Modelo> GetModeloCollection()
        {
            return _database.GetCollection<Modelo>("modelos");
        }

        public IMongoCollection<IntencaoVenda> GetIntencaoVendaCollection()
        {
            return _database.GetCollection<IntencaoVenda>("intencoesvenda");
        }
    }
}
