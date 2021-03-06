﻿using Autofac.Extensions.DependencyInjection;
using MemberShipManage.Infrastructure.Extension;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MemberShipManage.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).ConfigureLogging((context, LoggingBuilder) =>//ILogger
                {
                    LoggingBuilder.AddFilter("System", LogLevel.Warning); // 忽略系统的其他日志
                    LoggingBuilder.AddFilter("Microsoft", LogLevel.Warning);

                }).UseLog4Net();
    }
}
