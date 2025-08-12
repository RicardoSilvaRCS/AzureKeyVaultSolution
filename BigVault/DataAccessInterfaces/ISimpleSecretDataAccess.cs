using Models.Cache;

namespace DataAccessInterfaces {
    public interface ISimpleSecretDataAccess {
        CacheInfo GetSecret(string secret);
    }
}