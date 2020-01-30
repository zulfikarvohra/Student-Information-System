using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using StudentInformationSystem.Data;
using StudentInformationSystem.Entities;
using StudentInformationSystem.Handler;
using StudentInformationSystem.Interfaces;

namespace StudentInformationSystem
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
            services.AddDbContext<DatabaseContext>(options =>
                  options.UseSqlServer(Configuration.GetConnectionString("DatabaseContext")));

            services.AddScoped<StudentRepository>();
            services.AddControllers();
            services.AddTransient<IImageHandler, ImageHandler>();
            services.AddTransient<IImageWriter, ImageWriter>();


            services.AddCors();



            services.AddMvc()
      .AddNewtonsoftJson(options =>
      options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
  );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            
            app.UseRouting();
            app.UseStaticFiles(); 

            app.UseAuthorization();
            app.UseCors(builder =>
    builder.WithOrigins("http://localhost:4200"));
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
