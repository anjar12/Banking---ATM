using Gateway.Model;
using Gateway.Services;
using Infra.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Controllers
{
    public class AuthController : ControllerBase
    {
        private IConfiguration _config;
        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<AuthToken> access()
        {
            string Key = string.Empty;
            if (HttpContext.Request.Headers.TryGetValue(Settings.headerNameKey, out var value))
            {
                Key = value;
            }

            if (Key == Settings.headerValueKey)
            {
                AuthToken authToken = new TokenService(_config).PageGenerateToken("JwtAccess", "access");
                return authToken;
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
