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

namespace Diginovasi.Services.SalesOrderServices
{
    public class SalesOrderService:ISalesOrderService
    {
        private readonly CoreDbContext _context;
        private readonly IMapper _mapper;
        public SalesOrderService(CoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Add(SalesOrderDto dto)
        {
            if (_context.Customers.FirstOrDefault(c => c.Id == dto.CustomerId) == null)
            {
                throw new NullReferenceException($"Customer id: `{dto.Id}` tidak ditemukan");

            }
            var entity = _mapper.Map<SalesOrderDto, SalesOrder>(dto);
            _context.SalesOrders.Add(entity);
            entity.NoSalesOrder = $"{DateTime.Now.ToString("yyyyMM")}SL";
            bool result = await _context.SaveChangesAsync() > 0;
            entity.NoSalesOrder += string.Format("{0:D7}", entity.Id);
            _context.Entry(entity).State = EntityState.Modified;
            result = await _context.SaveChangesAsync() > 0;

            return entity.Id;
        }
        public async Task<int> Update(SalesOrderDto dto)
        {
            if (_context.Customers.FirstOrDefault(c => c.Id == dto.CustomerId) == null)
            {
                throw new NullReferenceException($"Customer id: `{dto.Id}` tidak ditemukan");

            }
            var entity = _mapper.Map<SalesOrderDto, SalesOrder>(dto);
            _context.SalesOrders.Update(entity);
            bool result = await _context.SaveChangesAsync() > 0;
            return entity.Id;
        }
        public async Task<IEnumerable<SalesOrderDto>> GetAll()
        {
            var list = await _context
                .SalesOrders
                .Include(c => c.Customer)
                .Include(c => c.SalesOrderItems)
                .ToListAsync();
            var dtoList = _mapper.Map<IEnumerable<SalesOrder>, IEnumerable<SalesOrderDto>>(list);
            return dtoList;
        }
        public async Task<SalesOrderDto> GetById(int id)
        {
            var entity = await _context
                .SalesOrders
                .Include(c => c.Customer)
                .Include(c => c.SalesOrderItems)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (entity == null)
                throw new NullReferenceException($"SalesOrder id: `{id}` tidak ditemukan");
            var dto = _mapper.Map<SalesOrder, SalesOrderDto>(entity);
            return dto;
        }
        public async Task<bool> Delete(int id)
        {
            var entity = _context.SalesOrders.FirstOrDefault(c => c.Id == id);
            if (entity == null)
                throw new NullReferenceException($"SalesOrder id: `{id}` tidak ditemukan");
            _context.SalesOrders.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
