using Diginovasi.DataTransferObjects.Sales;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Diginovasi.Services.SalesOrderServices
{
    public interface ISalesOrderService
    {
        Task<int> Add(SalesOrderDto dto);
        Task<int> Update(SalesOrderDto dto);
        Task<IEnumerable<SalesOrderDto>> GetAll();
        Task<SalesOrderDto> GetById(int id);
        Task<bool> Delete(int id);
    }
}
