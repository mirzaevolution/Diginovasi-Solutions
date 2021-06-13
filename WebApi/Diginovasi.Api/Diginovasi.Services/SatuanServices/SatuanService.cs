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
namespace Diginovasi.Services.SatuanServices
{
    public class SatuanService:ISatuanService
    {
        private readonly CoreDbContext _context;
        private readonly IMapper _mapper;
        public SatuanService(CoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Add(SatuanDto dto)
        {
            var entity = _mapper.Map<SatuanDto, Satuan>(dto);
            _context.Satuans.Add(entity);
            bool result = await _context.SaveChangesAsync() > 0;
            return entity.Id;
        }
        public async Task<int> Update(SatuanDto dto)
        {
            if(await _context.Satuans.FirstOrDefaultAsync(c => c.Id == dto.Id) == null)
            {
                throw new NullReferenceException($"Satuan id: `{dto.Id}` tidak ditemukan");

            }
            var entity = _mapper.Map<SatuanDto, Satuan>(dto);
            _context.Satuans.Update(entity);
            bool result = await _context.SaveChangesAsync() > 0;
            return entity.Id;
        }
        public async Task<IEnumerable<SatuanDto>> GetAll()
        {
            var list = await _context.Satuans.ToListAsync();
            var dtoList = _mapper.Map<IEnumerable<Satuan>, IEnumerable<SatuanDto>>(list);
            return dtoList;
        }
        public async Task<SatuanDto> GetById(int id)
        {
            var entity = await _context.Satuans.FirstOrDefaultAsync(c => c.Id == id);
            if (entity == null)
                throw new NullReferenceException($"Satuan id: `{id}` tidak ditemukan");
            var dto = _mapper.Map<Satuan, SatuanDto>(entity);
            return dto;
        }
        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Satuans.FirstOrDefaultAsync(c => c.Id == id);
            if (entity == null)
                throw new NullReferenceException($"Satuan id: `{id}` tidak ditemukan");
            _context.Satuans.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        
    }
}
