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
    public class SatuanService
    {
        private readonly CoreDbContext _context;
        private readonly IMapper _mapper;
        public SatuanService(CoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
