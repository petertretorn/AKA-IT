using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using FormManager.Data;
using Microsoft.EntityFrameworkCore;
using FormManager.Interfaces;
using FormManager.Services;
using System.Globalization;

namespace FormManager.API
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
            services.AddMvc()
            .AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();
            });
            
            var connectionString = Configuration["connectionStrings:formDBConnectionString"];
            services.AddDbContext<FormContext>(o => o.UseSqlServer(connectionString));

            services.AddScoped<DbContext, FormContext>();
            services.AddScoped<IFormRepository, FormRepository>();
            services.AddScoped<IFormService, FormService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, FormContext formContext)
        {
            var cultureInfo = new CultureInfo("da-DK");

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //uncomment this line when applying db migrations
            formContext.SeedData();

            app.UseMvc();
        }
    }
}
