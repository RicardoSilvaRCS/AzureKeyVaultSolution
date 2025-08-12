using Models.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces {
    public interface ICacheDataAccess {

        void AddSecret (CacheInfo cacheInfo);
        void AddSecrets (IEnumerable<CacheInfo> cacheInfo);
        CacheInfo GetSecretValue (string secret);
        IEnumerable<CacheInfo> GetSecrets (IEnumerable<string> secrets);
    }
}
