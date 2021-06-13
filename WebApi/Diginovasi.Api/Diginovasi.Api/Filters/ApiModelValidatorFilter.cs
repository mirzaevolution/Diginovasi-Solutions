using Diginovasi.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diginovasi.Api.Filters
{
    public class ApiModelValidatorFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid)
            {
                base.OnActionExecuting(context);
            }
            else
            {
                StringBuilder errors = new StringBuilder();
                foreach (var item in context.ModelState)
                {
                    if (item.Value.Errors != null && item.Value.Errors.Any())
                    {
                        foreach (var error in item.Value.Errors)
                        {
                            errors.AppendLine(error.ErrorMessage);
                        }
                    }
                }
                context.Result = new OkObjectResult(new BaseResponse
                {
                    Success = false,
                    Message = errors.ToString()
                });
            }
        }
    }
}
