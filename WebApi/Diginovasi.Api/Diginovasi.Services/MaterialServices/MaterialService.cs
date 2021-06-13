using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Diginovasi.Data;
using Diginovasi.BusinessObjects.Masters;
using Diginovasi.BusinessObjects.Sales;
using Diginovasi.DataTransferObjects.Masters;
using Diginovasi.DataTransferObjects.Sales;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Diginovasi.Services.MaterialServices
{
    public class MaterialService:IMaterialService
    {
        private readonly CoreDbContext _context;
        private readonly IMapper _mapper;
        public MaterialService(CoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Add(MaterialDto dto)
        {
            Satuan satuan = await _context.Satuans.FirstOrDefaultAsync(c => c.Kode == dto.KodeSatuan);
            if (satuan == null)
                throw new NullReferenceException($"Kode satuan: `{dto.KodeSatuan}` tidak ditemukan");
            Material material = _mapper.Map<MaterialDto, Material>(dto);
            material.SatuanId = satuan.Id;
            _context.Materials.Add(material);
            bool result = await _context.SaveChangesAsync() > 0;
            return material.Id;
        }
        public async Task<int> Update(MaterialDto dto)
        {
            Satuan satuan = await _context.Satuans.FirstOrDefaultAsync(c => c.Kode == dto.KodeSatuan);
            if (satuan == null)
                throw new NullReferenceException($"Kode satuan: `{dto.KodeSatuan}` tidak ditemukan");
            Material material = _mapper.Map<MaterialDto, Material>(dto);
            material.SatuanId = satuan.Id;
            _context.Materials.Update(material);
            bool result = await _context.SaveChangesAsync() > 0;
            return material.Id;
        }
        public async Task<IEnumerable<MaterialDto>> GetMaterials()
        {
            var list = await _context.Materials.ToListAsync();
            var dtoLis = _mapper.Map<IEnumerable<Material>, IEnumerable<MaterialDto>>(list);
            return dtoLis;
        }
        public async Task<MaterialDto> GetMaterialById(int id)
        {
            var entity = await _context.Materials.FirstOrDefaultAsync(c => c.Id == id);
            if (entity == null)
                throw new NullReferenceException($"Material id: `{id}` tidak ditemukan");
            var dto = _mapper.Map<Material, MaterialDto>(entity);
            return dto;
        }
    }
}
