using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diginovasi.DataTransferObjects.Masters;
using Diginovasi.Services.CustomerServices;
using AutoMapper;
using Diginovasi.Api.Models.Masters;
using Diginovasi.Api.Models;

namespace Diginovasi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseApiController
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        public CustomerController(ICustomerService satuanService, IMapper mapper)
        {
            _customerService = satuanService;
            _mapper = mapper;
        }
        [HttpPost(nameof(Add))]
        [Produces(DefaultContentType)]
        public async Task<IActionResult> Add([FromBody] CustomerRequest request)
        {
            var dto = _mapper.Map<CustomerRequest, CustomerDto>(request);
            int result = await _customerService.Add(dto);
            return Ok(new Response<int>
            {
                Data = result,
                Message = ConstructMessage(result > 0),
                Success = result > 0
            });
        }
        [HttpPut(nameof(Update))]
        [Produces(DefaultContentType)]
        public async Task<IActionResult> Update([FromBody] CustomerRequest request)
        {
            var dto = _mapper.Map<CustomerRequest, CustomerDto>(request);
            int result = await _customerService.Update(dto);
            return Ok(new Response<int>
            {
                Data = result,
                Message = ConstructMessage(result > 0),
                Success = result > 0
            });
        }
        [HttpGet(nameof(GetAll))]
        [Produces(DefaultContentType)]
        public async Task<IActionResult> GetAll()
        {
            var dtoList = await _customerService.GetAll();
            var response = new Response<IEnumerable<CustomerDto>>
            {
                Message = ConstructMessage(true),
                Data = dtoList
            };
            return Ok(response);
        }
        [HttpGet(nameof(GetById) + "/{id}")]
        [Produces(DefaultContentType)]

        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var dto = await _customerService.GetById(id);
            var response = new Response<CustomerDto>
            {
                Message = ConstructMessage(true),
                Data = dto
            };
            return Ok(response);
        }
        [HttpDelete(nameof(Delete) + "/{id}")]
        [Produces(DefaultContentType)]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var state = await _customerService.Delete(id);
            var response = new BaseResponse
            {
                Message = ConstructMessage(true),
                Success = state
            };
            return Ok(response);
        }
    }
}
