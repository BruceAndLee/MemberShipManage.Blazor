using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using Autofac;
using Microsoft.EntityFrameworkCore;
using MemberShipManage.Server.Models;
using MemberShipManage.Infrastructurer;
using MemberShipManage.Repository.CustomerRep;
using MemberShipManage.Service.CustomerSvc;
using System;
using AutoMapper;
using FluentValidation;
using MemberShipManage.Shared.CustomerDTO;
using MemberShipManage.Validation;
using Microsoft.OpenApi.Models;
using FluentValidation.AspNetCore;
namespace MemberShipManage.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            configuration.GetSection("AppSettings").Bind(CustomSettings.appSettings);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddFluentValidation();
            services.AddRazorPages();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddTransient<IValidator<CustomerCreateRequest>, CustomerCreateRequestValidator>();
            services.AddDbContext<MembershipManageContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DbConnectionString")));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "MemberShip Manager APIs",
                    Description = "Swagger Instruction",
                    Contact = new OpenApiContact
                    {
                        Email = "lilei1986abc@163.com",
                        Name = "Bruce Li",
                        Url = new Uri("http://www.51mordern.com")
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer Management API");
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<MembershipManageContext>().As<DbContext>().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CustomerService>().As<ICustomerService>().InstancePerLifetimeScope();
        }
    }
}
