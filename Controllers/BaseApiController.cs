using ClinicAPI.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected IActionResult SuccessResponse<T>(T data, string message = "Success", int statusCode = 200)
        {
            var response = new ApiResponse<T>(statusCode, message, data);
            return StatusCode(statusCode, response);

        }

        protected IActionResult ErrorResponse(string message, int statusCode = 400)
        {
            var response = new ApiResponse<string>(statusCode, message);

            return StatusCode(statusCode, response);

        }

        protected IActionResult NoContentResponse()
        {
            return NoContent();
        }
    }
}
