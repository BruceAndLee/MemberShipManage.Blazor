using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Linq;

namespace MemberShipManage.Server.ServiceFind
{
    public static class ConsulRegister
    {
        public static IServiceCollection AddConsulConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(consulConfig =>
            {
                var address = configuration.GetValue<string>("Consul:Host");
                consulConfig.Address = new Uri(address);
            }));
            return services;
        }

        public static IApplicationBuilder UseConsul(this IApplicationBuilder app)
        {
            var consulClient = app.ApplicationServices.GetRequiredService<IConsulClient>();
            var lifetime = app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>();
            var serviceOptions = app.ApplicationServices.GetRequiredService<IOptions<ServiceDiscoveryOptions>>();

            if (!(app.Properties["server.Features"] is FeatureCollection features)) return app;

            var serverFeatures = features.Get<IServerAddressesFeature>();
            //--var address = serverFeatures.Addresses.First();

            foreach (var address in serverFeatures.Addresses)
            {
                var uri = new Uri(address);
                var httpCheck = new AgentServiceCheck()
                {
                    DeregisterCriticalServiceAfter = TimeSpan.FromMinutes(1),
                    Interval = TimeSpan.FromSeconds(30),
                    HTTP = new Uri(new Uri(address), "HealthCheck").OriginalString
                };

                var registration = new AgentServiceRegistration()
                {
                    ID = $"{serviceOptions.Value.ServiceName}_{uri.Host}:{uri.Port}",
                    // servie name  
                    Name = "CustomerService",
                    Address = $"{uri.Host}",
                    Port = uri.Port
                };

                consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(true);
                consulClient.Agent.ServiceRegister(registration).ConfigureAwait(true);

                lifetime.ApplicationStopping.Register(() =>
                {
                    consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(true);
                });
            }
            return app;
        }
    }
}
