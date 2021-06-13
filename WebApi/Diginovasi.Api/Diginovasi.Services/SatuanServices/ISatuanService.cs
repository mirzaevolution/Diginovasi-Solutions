using Diginovasi.DataTransferObjects.Masters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Diginovasi.Services.SatuanServices
{
    public interface ISatuanService
    {
        Task<int> Add(SatuanDto dto);
        Task<int> Update(SatuanDto dto);
        Task<IEnumerable<SatuanDto>> GetAll();
        Task<SatuanDto> GetById(int id);
        Task<bool> Delete(int id);
    }
}
