using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Diginovasi.DataTransferObjects.Sales;
using AutoMapper;
using Diginovasi.Api.Models.Sales;
using Diginovasi.Api.Models;
using Diginovasi.Services.SalesOrderServices;

namespace Diginovasi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrderController : BaseApiController
    {
        private readonly ISalesOrderService _salesOrderService;
        private readonly IMapper _mapper;
        public SalesOrderController(ISalesOrderService salesOrderService, IMapper mapper)
        {
            _salesOrderService = salesOrderService;
            _mapper = mapper;
        }
        [HttpPost(nameof(Add))]
        [Produces(DefaultContentType)]
        public async Task<IActionResult> Add([FromBody] SalesOrderRequest request)
        {
            var dto = _mapper.Map<SalesOrderRequest, SalesOrderDto>(request);
            int result = await _salesOrderService.Add(dto);
            return Ok(new Response<int>
            {
                Data = result,
                Message = ConstructMessage(result > 0),
                Success = result > 0
            });
        }
        [HttpPut(nameof(Update))]
        [Produces(DefaultContentType)]
        public async Task<IActionResult> Update([FromBody] SalesOrderRequest request)
        {
            var dto = _mapper.Map<SalesOrderRequest, SalesOrderDto>(request);
            int result = await _salesOrderService.Update(dto);
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
            var dtoList = await _salesOrderService.GetAll();
            var response = new Response<IEnumerable<SalesOrderDto>>
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
            var dto = await _salesOrderService.GetById(id);
            var response = new Response<SalesOrderDto>
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
            var state = await _salesOrderService.Delete(id);
            var response = new BaseResponse
            {
                Message = ConstructMessage(true),
                Success = state
            };
            return Ok(response);
        }
    }
}
  