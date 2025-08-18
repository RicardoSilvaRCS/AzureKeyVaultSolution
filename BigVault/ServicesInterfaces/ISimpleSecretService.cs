using Models.Cache;

namespace ServicesInterfaces {
    public interface ISimpleSecretService {
        CacheInfo GetSecret(string secretKey);
        IEnumerable<CacheInfo> GetSecrets (IEnumerable<string> secrets);
        IEnumerable<CacheInfo> GetAllSecrets ();
    }
}