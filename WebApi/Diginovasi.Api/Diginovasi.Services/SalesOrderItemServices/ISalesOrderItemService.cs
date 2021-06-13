using Diginovasi.DataTransferObjects.Sales;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Diginovasi.Services.SalesOrderItemServices
{
    public interface ISalesOrderItemService
    {
        Task<int> Add(SalesOrderItemDto dto);
        Task<int> Update(SalesOrderItemDto dto);
        Task<IEnumerable<SalesOrderItemDto>> GetAll();
        Task<SalesOrderItemDto> GetById(int id);
        Task<bool> Delete(int id);
    }
}
