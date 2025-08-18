using DataAccessInterfaces;
using Microsoft.Extensions.DependencyInjection;
using Models.Cache;
using ServicesInterfaces;

namespace Services {
    public class RedisManagementServices : ICacheManagementServices {

        private ICacheDataAccess _cacheDataAccessService;
        private ISimpleSecretService _simpleSecretService;
        private IServiceProvider _serviceProvider;

        public RedisManagementServices (
            ICacheDataAccess cacheDataAccess,
            ISimpleSecretService simpleSecretService,
            IServiceProvider serviceProvider)
        {
            _cacheDataAccessService = cacheDataAccess;
            _simpleSecretService = simpleSecretService;
            _serviceProvider = serviceProvider;
            Init();
        }

        public async void Init () {
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var dbSecrets = await unitOfWork.Secrets.GetAllSecrets();
                var secrets = _simpleSecretService.GetSecrets(dbSecrets.Select(c => c.Name));
                _cacheDataAccessService.AddSecrets(secrets);
            }
        }

        public CacheInfo GetSecret (string secretKey) => _cacheDataAccessService.GetSecretValue (secretKey);

        public IEnumerable<CacheInfo> GetSecrets (IEnumerable<string> secretKey) => _cacheDataAccessService.GetSecrets(secretKey);

    }
}
