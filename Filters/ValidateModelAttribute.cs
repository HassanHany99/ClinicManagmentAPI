using ClinicAPI.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ClinicAPI.Filters
    
{
 
    // Global filter to catch model validation errors and return formatted response
    public class ValidateModelAttribute :  ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState
                      .Where(x => x.Value.Errors.Count > 0)
                      .ToDictionary(
                    k => k.Key,
                    v => v.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                  );


                var errorResponse = new ApiResponse<Dictionary<string, string[]>>
                {
                    StatusCode = 400,
                    Success = false,
                    Message = "One or more validation errors occurred.",
                    Data = errors
                };


                context.Result = new BadRequestObjectResult(errorResponse);

            }

        }


    }
}
