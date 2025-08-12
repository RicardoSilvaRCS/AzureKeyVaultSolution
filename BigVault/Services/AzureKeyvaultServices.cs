using DataAccessInterfaces;
using Models.Cache;
using ServicesInterfaces;

namespace Services {
    public class AzureKeyvaultServices : ISimpleSecretService {

        private readonly ISimpleSecretDataAccess _keyvaultPersistence;

        public AzureKeyvaultServices(ISimpleSecretDataAccess keyvaultPersistence) {
            _keyvaultPersistence = keyvaultPersistence;
        }

        public CacheInfo GetSecret(string secretKey) => _keyvaultPersistence.GetSecret(secretKey);
    }
}