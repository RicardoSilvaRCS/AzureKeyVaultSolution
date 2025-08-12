using Models.Cache;

namespace ServicesInterfaces {
    public interface ICacheManagementServices {

        CacheInfo GetSecret (string secretKey);
        IEnumerable<CacheInfo> GetSecrets (IEnumerable<string> secretKey);
    }
}
