using System;
using System.Collections.Generic;
using System.Linq;
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
using Ticket2.Middleware;
using Ticket2.Services.TicketServices;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Ticket2
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
            
            services.AddControllers().AddNewtonsoftJson();

            services.AddDbContext<Ticket2Context>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("TicketContext")));
            
            services.AddSwaggerGen(c => { c.SwaggerDoc("v4", new OpenApiInfo {Title = "Ticket2", Version = "v4"}); });

            services.AddApiVersioning();
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<ITicketService, TicketService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v4/swagger.json", "Ticket2 v4"));
                app.UseJsonValid();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}