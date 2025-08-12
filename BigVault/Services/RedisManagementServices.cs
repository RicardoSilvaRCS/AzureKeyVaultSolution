using DataAccessInterfaces;
using Models.Cache;
using ServicesInterfaces;

namespace Services {
    public class RedisManagementServices : ICacheManagementServices {

        private ICacheDataAccess _cacheDataAccessService;
        private ISimpleSecretService simpleSecretService;

        public RedisManagementServices(ICacheDataAccess cacheDataAccess, ISimpleSecretService simpleSecretService) { 
            _cacheDataAccessService = cacheDataAccess;
            simpleSecretService = simpleSecretService;
            Init();
        }

        public void Init () {
            _cacheDataAccessService.AddSecret(new CacheInfo {
                Name = "teste",
                Value = "teste successfull"
            });
        }

        public CacheInfo GetSecret (string secretKey) => _cacheDataAccessService.GetSecretValue (secretKey);

        public IEnumerable<CacheInfo> GetSecrets (IEnumerable<string> secretKey) => _cacheDataAccessService.GetSecrets(secretKey);

    }
}
