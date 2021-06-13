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
namespace Diginovasi.Services.CustomerServices
{
    public class CustomerService:ICustomerService
    {
        private readonly CoreDbContext _context;
        private readonly IMapper _mapper;
        public CustomerService(CoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Add(CustomerDto dto)
        {
            var entity = _mapper.Map<CustomerDto, Customer>(dto);
            _context.Customers.Add(entity);
            entity.NoCustomer = DateTime.Now.Ticks.ToString("D7");
            bool result = await _context.SaveChangesAsync() > 0;
            entity.NoCustomer = entity.Id.ToString("D7");
            _context.Entry(entity).State = EntityState.Modified;
            result = await _context.SaveChangesAsync() > 0;
            return entity.Id;
        }
        public async Task<int> Update(CustomerDto dto)
        {
            if (await _context.Customers.FirstOrDefaultAsync(c => c.Id == dto.Id) == null)
            {
                throw new NullReferenceException($"Customer id: `{dto.Id}` tidak ditemukan");

            }
            var entity = _mapper.Map<CustomerDto, Customer>(dto);
            if (!_context.Customers.Local.Contains(entity))
            {
                _context.Customers.Attach(entity);
            }
            _context.Entry(entity).State = EntityState.Modified;
            bool result = await _context.SaveChangesAsync() > 0;
            return entity.Id;
        }
        public async Task<IEnumerable<CustomerDto>> GetAll()
        {
            var list = await _context.Customers.ToListAsync();
            var dtoList = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDto>>(list);
            return dtoList;
        }
        public Task<CustomerDto> GetById(int id)
        {
            var entity = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (entity == null)
                throw new NullReferenceException($"Customer id: `{id}` tidak ditemukan");
            var dto = _mapper.Map<Customer, CustomerDto>(entity);
            return Task.FromResult(dto);
        }
        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
            if (entity == null)
                throw new NullReferenceException($"Customer id: `{id}` tidak ditemukan");
            _context.Customers.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
