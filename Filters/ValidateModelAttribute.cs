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
              var errors= context.ModelState.
                    Where(e => e.Value.Errors.Count > 0)
                    .SelectMany(e => e.Value.Errors) 
                    .Select(e => e.ErrorMessage)
                    .ToList();

                var errorResponse = new
                {
                    statusCode = 400,
                    errors = errors
                };

                context.Result = new BadRequestObjectResult(errorResponse);

            }

        }


    }
}
