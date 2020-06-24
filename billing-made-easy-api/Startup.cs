using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using billing_made_easy_api.Models;
using billing_made_easy_api.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using billing_made_easy_api.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection.Extensions;
using billing_made_easy_api.Services.Implementations;
using billing_made_easy_api.Repositories.Implementations;
using AutoMapper;

namespace billing_made_easy_api
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
            services.AddDbContext<easybillContext>(opts =>
                    opts.UseSqlServer(Configuration.GetConnectionString("BillDBConnection"))) ;
            services.AddScoped<easybillContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repositories.Implementations.Repository<>));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            // Register services for DI
            services.TryAddScoped<IMasterService, MasterService>();
            services.TryAddScoped<IPaymentDetailsService, PaymentDetailsService>();
            services.TryAddScoped<IPartyService, PartyService>();
            services.TryAddScoped<IBillService, BillService>();
            services.TryAddScoped<IDeliveryService, DeliveryService>();
            // Register repositories for DI
            services.TryAddScoped<IPaymentStatusMasterRepository, PaymentStatusMasterRepository>();
            services.TryAddScoped<IPaymentTypeMasterRepository, PaymentTypeMasterRepository>();
            services.TryAddScoped<IPaymentDetailsRepository, PaymentDetailsRepository>();
            services.TryAddScoped<IPartyDetailsRepository, PartyDetailsRepository>();
            services.TryAddScoped<IBillRepository, BillRepository>();
            services.TryAddScoped<IDeliveryRepository, DeliveryRepository>();
            services.AddAutoMapper(typeof(Startup));

            // Register cors
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();


            app.UseCors(options => options.AllowAnyOrigin());
        }
    }
}
