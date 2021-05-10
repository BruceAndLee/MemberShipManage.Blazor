using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using MatBlazor;

namespace MemberShipManage.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddBootstrapBlazor((options) =>
            {
                options.ToastDelay = 3000;
            });
            builder.Services.AddBootstrapBlazorTableExcelExport();

            builder.Services.AddMatBlazor();
            await builder.Build().RunAsync();
        }
    }
}
