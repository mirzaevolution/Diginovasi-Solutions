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
namespace Diginovasi.Services.SalesOrderItemServices
{
    public class SalesOrderItemService:ISalesOrderItemService
    {
        private readonly CoreDbContext _context;
        private readonly IMapper _mapper;
        public SalesOrderItemService(CoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Add(SalesOrderItemDto dto)
        {
            if (await _context.Materials.FirstOrDefaultAsync(c => c.Id == dto.MaterialId) == null)
            {
                throw new NullReferenceException($"Material id: `{dto.Id}` tidak ditemukan");

            }
            var entity = _mapper.Map<SalesOrderItemDto, SalesOrderItem>(dto);
            _context.SalesOrderItems.Add(entity);
            bool result = await _context.SaveChangesAsync() > 0;
            return entity.Id;
        }
        public async Task<int> Update(SalesOrderItemDto dto)
        {
            if (await _context.Materials.FirstOrDefaultAsync(c => c.Id == dto.MaterialId) == null)
            {
                throw new NullReferenceException($"Material id: `{dto.Id}` tidak ditemukan");

            }
            var entity = _mapper.Map<SalesOrderItemDto, SalesOrderItem>(dto);
            _context.SalesOrderItems.Update(entity);
            bool result = await _context.SaveChangesAsync() > 0;
            return entity.Id;
        }
        public async Task<IEnumerable<SalesOrderItemDto>> GetAll()
        {
            var list = await _context.SalesOrderItems
                .Include(c => c.SalesOrder)
                .Include(c => c.Material)
                .ThenInclude(c => c.Satuan)
                .ToListAsync();
            var dtoList = _mapper.Map<IEnumerable<SalesOrderItem>, IEnumerable<SalesOrderItemDto>>(list);
            return dtoList;
        }
        public async Task<SalesOrderItemDto> GetById(int id)
        {
            var entity = await _context
                .SalesOrderItems
                .Include(c => c.SalesOrder)
                .Include(c => c.Material)
                .ThenInclude(c => c.Satuan)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (entity == null)
                throw new NullReferenceException($"SalesOrderItem id: `{id}` tidak ditemukan");
            var dto = _mapper.Map<SalesOrderItem, SalesOrderItemDto>(entity);
            return dto;
        }
        public async Task<bool> Delete(int id)
        {
            var entity = await _context.SalesOrderItems.FirstOrDefaultAsync(c => c.Id == id);
            if (entity == null)
                throw new NullReferenceException($"SalesOrderItem id: `{id}` tidak ditemukan");
            _context.SalesOrderItems.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
