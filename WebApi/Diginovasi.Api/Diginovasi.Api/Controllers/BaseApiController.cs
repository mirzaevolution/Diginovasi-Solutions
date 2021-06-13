using Diginovasi.Api.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diginovasi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiModelValidatorFilter]
    public class BaseApiController : ControllerBase
    {
        public const string DefaultContentType = "application/json";
        protected string ConstructMessage(bool state) => state ? "Operation completed successfully" : "Operation failed to complete. Please try again";
    }
}
