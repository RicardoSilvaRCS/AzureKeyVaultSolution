using Models.Cache;

namespace ServicesInterfaces {
    public interface ISimpleSecretService {
        CacheInfo GetSecret(string secretKey);
    }
}