using Infra.Data.Models;
using Infra.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Service_Masters.Controllers
{
    /// <summary>
   [Authorize(AuthenticationSchemes = "access_auth")]
    /// </summary>
    public class AuthController : Controller
    {
        private readonly IUnitOfWorks _unitOfWork;

        public AuthController(IUnitOfWorks unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody] PostData<Login> postData)
        {
            var response = await _unitOfWork.master.Login(postData);
            if (response.Item1)
            {
                ResultValue<View_Credentials> resultValue = response.Item3;
                return Ok(resultValue);
            }
            else
            {
                Result result = response.Item2;
                return Ok(result);
            }
        }
    }
}
