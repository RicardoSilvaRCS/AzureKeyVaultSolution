using Models.Cache;

namespace DataAccessInterfaces {
    public interface ISimpleSecretDataAccess {
        CacheInfo GetSecret(string secret);
        IEnumerable<CacheInfo> GetSecrets (IEnumerable<string> secrets);
        IEnumerable<CacheInfo> GetAllSecrets ();
    }
}