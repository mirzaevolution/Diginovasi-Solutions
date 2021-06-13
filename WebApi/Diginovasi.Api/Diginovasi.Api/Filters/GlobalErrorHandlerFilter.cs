using Diginovasi.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diginovasi.Api.Filters
{
    public class GlobalErrorHandlerFilter: ExceptionFilterAttribute
    {
        private ILogger<GlobalErrorHandlerFilter> _logger;
        public GlobalErrorHandlerFilter(ILogger<GlobalErrorHandlerFilter> logger)
        {
            _logger = logger;
        }
        public override void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                string error = context.Exception.Message;
                
                context.Result = new OkObjectResult(new BaseResponse
                {
                    Message = error,
                    Success = false
                });




                context.ExceptionHandled = true;
            }
            base.OnException(context);
        }
    }
}
