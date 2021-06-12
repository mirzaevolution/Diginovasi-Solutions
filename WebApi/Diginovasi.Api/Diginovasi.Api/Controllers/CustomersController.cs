using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diginovasi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ILogger<CustomersController> _logger;
        public CustomersController(ILogger<CustomersController> logger)
        {
            this._logger = logger;
        }
        [HttpGet("GetCustomers")]
        public IActionResult Get()
        {
            _logger.LogInformation("[GET] /customers/");
            return Ok(new
            {
                data = "Mirza"
            });
        }
    }
}
