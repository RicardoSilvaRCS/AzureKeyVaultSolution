using Microsoft.AspNetCore.Mvc;
using ServicesInterfaces;

namespace BigKeyVault.Controllers {

    [ApiController]
    [Route("api/secrets")]
    public class SecretsController : ControllerBase {

        private readonly  ICacheManagementServices _cacheServices;

        public SecretsController (ICacheManagementServices cacheServices) {
           _cacheServices = cacheServices;
        }

        [HttpGet("{key}")]
        public async Task<IActionResult> GetSecret (string key) {
            return Ok(_cacheServices.GetSecret(key));
        }
    }
}
