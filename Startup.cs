using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.VisualBasic;
using WatchingOrchestrator.Data;
using WatchingOrchestrator.Profiles;
using WatchingOrchestrator.Services;

namespace WatchingOrchestrator
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            Console.WriteLine($"La stringa di connessione è : {Configuration.GetConnectionString("WatchingDbString")} ");
            //services.AddDbContext<WatchingDbContext>(opt => opt.UseInMemoryDatabase("WatchDbInMemory"));
            services.AddDbContext<WatchingDbContext>(
                opt => opt.UseSqlServer(Configuration.GetConnectionString("WatchingDbString"))
            );

            services.AddScoped<IWatchingOrchestratorServices, WatchingOrchestratorServices>();
            services.AddScoped<ICustomMapper, CustomMapper>();
            services.AddLogging();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WatchingOrchestrator", Version = "v1" });
            });
            //services.AddControllers().AddJsonOptions(x =>
            //   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
            
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WatchingOrchestrator v1"));
            }

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


           //PrepDb.PreparePopulation(app, env);
        }
    }
}
