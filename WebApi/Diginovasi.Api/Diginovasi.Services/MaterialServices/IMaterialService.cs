using Diginovasi.DataTransferObjects.Masters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Diginovasi.Services.MaterialServices
{
    public interface IMaterialService
    {
        Task<int> Add(MaterialDto dto);
        Task<int> Update(MaterialDto dto);
        Task<IEnumerable<MaterialDto>> GetMaterials();
        Task<MaterialDto> GetMaterialById(int id);
    }
}
