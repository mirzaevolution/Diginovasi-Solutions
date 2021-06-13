using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore;
using Diginovasi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.ResponseCompression;
using Diginovasi.Api.Filters;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace Diginovasi.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<CoreDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
            services.ConfigureServices();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Diginovasi API",
                    Version = "1.0"
                });
            });
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<GzipCompressionProvider>();
            });
            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = System.IO.Compression.CompressionLevel.Optimal;
            });
            services.AddControllers(options =>
            {
                options.Filters.Add<GlobalErrorHandlerFilter>();
            }).ConfigureApiBehaviorOptions(options=>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(options =>
            {
                options.AllowAnyOrigin();
                options.AllowAnyHeader();
                options.AllowAnyMethod();
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions
            {
                
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "Uploads")),
                RequestPath = "/Uploads"
            }); 
            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "Diginovasi API");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
