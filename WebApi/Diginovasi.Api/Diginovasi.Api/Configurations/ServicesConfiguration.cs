using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Diginovasi.Services.MaterialServices;
using Diginovasi.Services.SatuanServices;
using Diginovasi.Services.CustomerServices;
using Diginovasi.Services.SalesOrderItemServices;

namespace Diginovasi.Api
{
    public static class ServicesConfiguration
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<ISatuanService, SatuanService>();
            services.AddScoped<IMaterialService, MaterialService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ISalesOrderItemService, SalesOrderItemService>();
        }
    }
}
