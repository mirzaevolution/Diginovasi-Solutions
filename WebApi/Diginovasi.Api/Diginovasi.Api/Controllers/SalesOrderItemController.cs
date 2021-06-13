using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diginovasi.DataTransferObjects.Sales;
using Diginovasi.Services.SalesOrderItemServices;
using AutoMapper;
using Diginovasi.Api.Models.Sales;
using Diginovasi.Api.Models;


namespace Diginovasi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrderItemController : BaseApiController
    {
        private readonly ISalesOrderItemService _salesOrderItemService;
        private readonly IMapper _mapper;
        public SalesOrderItemController(ISalesOrderItemService salesOrderItemService, IMapper mapper)
        {
            _salesOrderItemService = salesOrderItemService;
            _mapper = mapper;
        }
        [HttpPost(nameof(Add))]
        [Produces(DefaultContentType)]
        public async Task<IActionResult> Add([FromBody] SalesOrderItemRequest request)
        {
            var dto = _mapper.Map<SalesOrderItemRequest, SalesOrderItemDto>(request);
            int result = await _salesOrderItemService.Add(dto);
            return Ok(new Response<int>
            {
                Data = result,
                Message = ConstructMessage(result > 0),
                Success = result > 0
            });
        }
        [HttpPut(nameof(Update))]
        [Produces(DefaultContentType)]
        public async Task<IActionResult> Update([FromBody] SalesOrderItemRequest request)
        {
            var dto = _mapper.Map<SalesOrderItemRequest, SalesOrderItemDto>(request);
            int result = await _salesOrderItemService.Update(dto);
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
            var dtoList = await _salesOrderItemService.GetAll();
            var response = new Response<IEnumerable<SalesOrderItemDto>>
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
            var dto = await _salesOrderItemService.GetById(id);
            var response = new Response<SalesOrderItemDto>
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
            var state = await _salesOrderItemService.Delete(id);
            var response = new BaseResponse
            {
                Message = ConstructMessage(true),
                Success = state
            };
            return Ok(response);
        }
    }
}
