using Diginovasi.DataTransferObjects.Masters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Diginovasi.Services.CustomerServices
{
    public interface ICustomerService
    {
        Task<int> Add(CustomerDto dto);
        Task<int> Update(CustomerDto dto);
        Task<IEnumerable<CustomerDto>> GetAll();
        Task<CustomerDto> GetById(int id);
        Task<bool> Delete(int id);
    }
}
