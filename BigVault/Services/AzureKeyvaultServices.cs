using DataAccessInterfaces;
using Models.Cache;
using ServicesInterfaces;

namespace Services {
    public class AzureKeyvaultServices : ISimpleSecretService {

        private readonly ISimpleSecretDataAccess _keyvaultPersistence;

        public AzureKeyvaultServices(ISimpleSecretDataAccess keyvaultPersistence) {
            _keyvaultPersistence = keyvaultPersistence;
        }

        public IEnumerable<CacheInfo> GetAllSecrets () {
            throw new NotImplementedException();
        }

        public CacheInfo GetSecret(string secretKey) => _keyvaultPersistence.GetSecret(secretKey);

        public IEnumerable<CacheInfo> GetSecrets (IEnumerable<string> secrets) => _keyvaultPersistence.GetSecrets(secrets);
    }
}