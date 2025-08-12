using DataAccessInterfaces;
using Models.Cache;
using StackExchange.Redis;

namespace RedisDataAccess {
    public class RedisPersistence : ICacheDataAccess {

        private IDatabase _redisDb;

        public RedisPersistence () {

            var muxer = ConnectionMultiplexer.Connect(
                new ConfigurationOptions {
                    EndPoints = { { "redis-xxxx.xxxx.europe-xxxx-1.gce.xxxx.redis-cloud.com", 13778 } },
                    User = "",
                    Password = ""
                }
            );

            _redisDb = muxer.GetDatabase();
        }

        public void AddSecret (CacheInfo cacheInfo) {
            _redisDb.StringSet(cacheInfo.Name, cacheInfo.Value);
        }

        public void AddSecrets (IEnumerable<CacheInfo> cacheInfo) {
            foreach (var currentSecret in cacheInfo) {
                _redisDb.StringSet(currentSecret.Name, currentSecret.Value);
            }
        }

        public CacheInfo GetSecretValue (string secret) {
            return new CacheInfo {
                Name = secret,
                Value = _redisDb.StringGet(secret)
            };
        }

        public IEnumerable<CacheInfo> GetSecrets (IEnumerable<string> secrets) {
            return secrets.Select(c => {
                var secretValue = _redisDb.StringGet(c);
                return new CacheInfo {
                    Name = c,
                    Value = secretValue
                };
            });
        }
    }
}
