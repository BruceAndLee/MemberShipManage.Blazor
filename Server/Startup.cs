using Autofac;
using FluentValidation.AspNetCore;
using MemberShipManage.Infrastructure.MiddleWare;
using MemberShipManage.Infrastructurer;
using MemberShipManage.Repository.CustomerRep;
using MemberShipManage.Repository.UserRep;
using MemberShipManage.Server.Authetication;
using MemberShipManage.Server.Filters;
using MemberShipManage.Server.Models;
using MemberShipManage.Service.CustomerSvc;
using MemberShipManage.Service.UserSvc;
using MemberShipManage.Validations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //configuration.GetSection("AppSettings").Bind(CustomSettings.AppSettings);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(SystemExceptionFilter));
            });
            services.AddControllersWithViews().AddFluentValidation();
            services.AddRazorPages();
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = true;
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.RegisterValidators();
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

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "在下框中输入请求头中需要添加Jwt授权Token：Bearer Token",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference {
                                        Type = ReferenceType.SecurityScheme,
                                        Id = "Bearer"}
                        },new string[] { }
                    }
                });

                c.OperationFilter<AuthTokenHeaderFilter>();
            });

            JWTTokenOptions JWTTokenOptions = new JWTTokenOptions();
            services.Configure<JWTTokenOptions>(Configuration.GetSection("JWTToken"));
            Configuration.Bind("JWTToken", JWTTokenOptions);

            services.AddSingleton(JWTTokenOptions);

            services.AddAuthentication(option =>
            {
                //默认身份验证模式
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                //默认方案
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(option =>
            {
                //设置元数据地址或权限是否需要HTTP
                option.RequireHttpsMetadata = false;
                option.SaveToken = true;
                //令牌验证参数
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    //获取或设置要使用的Microsoft.IdentityModel.Tokens.SecurityKey用于签名验证。
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.
                    GetBytes(JWTTokenOptions.Secret)),
                    //获取或设置一个System.String，它表示将使用的有效发行者检查代币的发行者。 
                    ValidIssuer = JWTTokenOptions.Issuer,
                    //获取或设置一个字符串，该字符串表示将用于检查的有效受众反对令牌的观众。
                    ValidAudience = JWTTokenOptions.Audience,
                    //是否验证发起人
                    ValidateIssuer = true,
                    //是否验证订阅者
                    ValidateAudience = false,
                    ////允许的服务器时间偏移量
                    ClockSkew = TimeSpan.Zero,
                    ////是否验证Token有效期，使用当前时间与Token的Claims中的NotBefore和Expires对比
                    ValidateLifetime = true
                };
                //如果jwt过期，在返回的header中加入Token-Expired字段为true，前端在获取返回header时判断
                option.Events = new JwtBearerEvents()
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
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
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors(p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            //app.UseMiddleware<SystemExceptionHandleMiddleware>();
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
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CustomerService>().As<ICustomerService>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<JwtTokenHelper>().InstancePerLifetimeScope();
        }
    }
}
