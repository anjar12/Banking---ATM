using Infra.Data.Models;
using Infra.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Service_Transactional.Controllers
{
    /// <summary>
    [Authorize(AuthenticationSchemes = "access_auth")]
    /// </summary>

    public class TransactionalController : Controller
    {
        private readonly IUnitOfWorks _unitOfWork;

        public TransactionalController(IUnitOfWorks unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> InsertCustomer([FromBody] PostData<Insert_Customer> postData)
        {
            var response = await _unitOfWork.transactional.Insert_Customer(postData);
            Result result = response.Item2;
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCustomer([FromBody] PostData<Update_Customer> postData)
        {
            var response = await _unitOfWork.transactional.Update_Customer(postData);
            Result result = response.Item2;
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteCustomer([FromBody] PostData<Delete_Customer> postData)
        {
            var response = await _unitOfWork.transactional.Delete_Customer(postData);
            Result result = response.Item2;
            return Ok(result);
        }

    }
}
