using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MemberShipManage.Infrastructurer
{
    public class AppSettings
    {
        private static readonly IConfigurationRoot _config;

        static AppSettings()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                    .AddJsonFile("appsettings.json", true, true);
            _config = builder.Build();
        }

        public string DbScriptXmlPath => _config["AppSettings:DbScriptXmlPath"];

        public string ClientID => _config["AppSettings:ClientID"];

        public static class Caching
        {
            /// <summary>
            /// RedisConnectionString
            /// </summary>
            public static string RedisConnectionString => _config["Caching:RedisConnectionString"];

            /// <summary>
            /// 是否开启
            /// </summary>
            public static bool IsOpen => Convert.ToBoolean(_config["Caching:IsOpen"]);
        }
    }
}
