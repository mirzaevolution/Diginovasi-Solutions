using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diginovasi.DataTransferObjects.Masters;
using Diginovasi.Services.SatuanServices;
using AutoMapper;
using Diginovasi.Api.Models.Masters;
using Diginovasi.Api.Models;

namespace Diginovasi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SatuanController : BaseApiController
    {
        private readonly ISatuanService _satuanService;
        private readonly IMapper _mapper;
        public SatuanController(ISatuanService satuanService, IMapper mapper)
        {
            _satuanService = satuanService;
            _mapper = mapper;
        }
        [HttpPost(nameof(Add))]
        [Produces(DefaultContentType)]
        public async Task<IActionResult> Add([FromBody] SatuanRequest request)
        {
            var dto = _mapper.Map<SatuanRequest, SatuanDto>(request);
            int result =  await _satuanService.Add(dto);
            return Ok(new Response<int>
            {
                Data = result,
                Message = ConstructMessage(result > 0),
                Success = result > 0
            });
        }
        [HttpPut(nameof(Update))]
        [Produces(DefaultContentType)]
        public async Task<IActionResult> Update([FromBody] SatuanRequest request)
        {
            var dto = _mapper.Map<SatuanRequest, SatuanDto>(request);
            int result = await _satuanService.Update(dto);
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
            var dtoList = await _satuanService.GetAll();
            var response = new Response<IEnumerable<SatuanDto>>
            {
                Message = ConstructMessage(true),
                Data = dtoList
            };
            return Ok(response);
        }
        [HttpGet(nameof(GetById) + "/{id}")]
        [Produces(DefaultContentType)]

        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var dto = await _satuanService.GetById(id);
            var response = new Response<SatuanDto>
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
            var state = await _satuanService.Delete(id);
            var response = new BaseResponse
            {
                Message = ConstructMessage(true),
                Success = state
            };
            return Ok(response);
        }
    }
}
