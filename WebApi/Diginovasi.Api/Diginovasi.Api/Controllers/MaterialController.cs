using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diginovasi.DataTransferObjects.Masters;
using AutoMapper;
using Diginovasi.Api.Models.Masters;
using Diginovasi.Api.Models;
using Diginovasi.Services.MaterialServices;

namespace Diginovasi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : BaseApiController
    {
        private readonly IMaterialService _materialService;
        private readonly IMapper _mapper;
        public MaterialController(IMaterialService materialService, IMapper mapper)
        {
            _materialService = materialService;
            _mapper = mapper;
        }
        [HttpPost(nameof(Add))]
        [Produces(DefaultContentType)]
        public async Task<IActionResult> Add([FromForm] MaterialRequest request)
        {
            if (request.Gambar != null)
            {
                string imageLocation = GlobalAppScopedHelper.UploadFile(request.Gambar);
                request.UrlGambar = imageLocation;

            }


            var dto = _mapper.Map<MaterialRequest, MaterialDto>(request);
            int result = await _materialService.Add(dto);
            return Ok(new Response<int>
            {
                Data = result,
                Message = ConstructMessage(result > 0),
                Success = result > 0
            });
        }
        [HttpPut(nameof(Update))]
        [Produces(DefaultContentType)]
        public async Task<IActionResult> Update([FromForm] MaterialRequest request)
        {
            if (request.Gambar != null)
            {
                string imageLocation = GlobalAppScopedHelper.UploadFile(request.Gambar);
                request.UrlGambar = imageLocation;

            }

            var dto = _mapper.Map<MaterialRequest, MaterialDto>(request);
            int result = await _materialService.Update(dto);
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
            var dtoList = await _materialService.GetAll();
            var response = new Response<IEnumerable<MaterialDto>>
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
            var dto = await _materialService.GetById(id);
            var response = new Response<MaterialDto>
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
            var state = await _materialService.Delete(id);
            var response = new BaseResponse
            {
                Message = ConstructMessage(true),
                Success = state
            };
            return Ok(response);
        }
    }
}
