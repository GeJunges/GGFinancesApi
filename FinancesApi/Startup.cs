using System;
using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;
using FinancesApi.DI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using FinancesApi.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FinancesApi.Filters;

namespace FinancesApi {
    public class Startup {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services) {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => {
                options.Authority = Configuration["FireBaseConfigurations:Url"];
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = Configuration["FireBaseConfigurations:Url"],
                    ValidateAudience = true,
                    ValidAudience = Configuration["FireBaseConfigurations:ProjectId"],
                    ValidateLifetime = true
                };
            });

            services.AddMvc(options => {
                options.Filters.Add(new ExceptionFilter());
                options.Filters.Add(new ValidateModelAttribute());
            })
            .AddJsonOptions(options => {
                SetJsonConfigurations(options);
            });

            return SetDependencyInjectionConfigurations(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            app.UseAuthentication();
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        private static void SetJsonConfigurations(Microsoft.AspNetCore.Mvc.MvcJsonOptions options) {
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        private static IServiceProvider SetDependencyInjectionConfigurations(IServiceCollection services) {
            var container = new WindsorContainer();
            container.Install(new InstallFindancesApi());

            return WindsorRegistrationHelper.CreateServiceProvider(container, services);
        }
    }
}
