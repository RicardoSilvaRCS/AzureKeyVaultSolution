using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using DataAccessInterfaces;
using Models.Cache;

namespace AzureDataAccess {
    public class AzureKeyvaultPersistence : ISimpleSecretDataAccess {

        private readonly SecretClient _secretClient;

        public AzureKeyvaultPersistence () {
            // Replace with your actual Key Vault URI
            var keyVaultUrl = "https://<your-keyvault-name>.vault.azure.net/";
            _secretClient = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
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
    }
}