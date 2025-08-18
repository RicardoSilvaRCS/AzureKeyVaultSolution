using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using DataAccessInterfaces;
using Models.Cache;

namespace AzureDataAccess {
    public class AzureKeyvaultPersistence : ISimpleSecretDataAccess {

        private readonly SecretClient _secretClient;

        public AzureKeyvaultPersistence () {
            // Replace with your actual Key Vault URI
            //var keyVaultUrl = "https://<your-keyvault-name>.vault.azure.net/";
            //_secretClient = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
        }

        public CacheInfo GetSecret(string secret) {
            try {
                var response = _secretClient.GetSecret(secret);
                return new CacheInfo {
                    Name = secret,
                    Value = response.Value.Value
                };
            } catch (Azure.RequestFailedException) {
                return new CacheInfo {
                    Name = secret,
                    Value = null
                };
            }
        }

        public IEnumerable<CacheInfo> GetAllSecrets () {
            return new List<CacheInfo> {
                new CacheInfo {
                    Name = "DatabaseConnectionString",
                    Value = "Server=db-prod-01;Database=maindb;Trusted_Connection=True;",
                    TTL = 3600
                },
                new CacheInfo {
                    Name = "ApiKey",
                    Value = "ak_prod_9x8cv7b6n5m4l3k2j",
                    TTL = 7200
                },
                new CacheInfo {
                    Name = "SmtpSettings",
                    Value = "smtp.company.com:587;username=mailer;",
                    TTL = 1800
                },
                new CacheInfo {
                    Name = "RedisConfiguration",
                    Value = "redis-cache.company.net:6379,password=secret",
                    TTL = 3600
                },
                new CacheInfo {
                    Name = "JwtSigningKey",
                    Value = "bXktc2VjcmV0LWtleS1mb3Itand0LXNpZ25pbmc=",
                    TTL = 86400
                },
                new CacheInfo {
                    Name = "StorageAccountKey",
                    Value = "DefaultEndpointsProtocol=https;AccountName=storage001;AccountKey=xxxx",
                    TTL = 3600
                },
                new CacheInfo {
                    Name = "LoggingLevel",
                    Value = "Information",
                    TTL = 900
                },
                new CacheInfo {
                    Name = "ServiceBusConnection",
                    Value = "Endpoint=sb://servicebus.company.net/;SharedAccessKeyName=RootManageSharedAccessKey;",
                    TTL = 4800
                },
                new CacheInfo {
                    Name = "CorsOrigins",
                    Value = "https://app1.company.com,https://app2.company.com",
                    TTL = 1200
                },
                new CacheInfo {
                    Name = "FeatureFlags",
                    Value = "{'newUI':true,'beta':false,'maintenance':false}",
                    TTL = 300
                }
            };
        }

        public IEnumerable<CacheInfo> GetSecrets (IEnumerable<string> secrets) {
            return GetAllSecrets().Where(c => secrets.Contains(c.Name)).Select(c => new CacheInfo {
                Name = c.Name,
                Value = c.Value,
                TTL = c.TTL
            });
        }
    }
}