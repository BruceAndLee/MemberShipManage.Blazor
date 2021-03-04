using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ConsulServiceFind
{
    [Route("[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        private IConfiguration _IConfiguration = null;
        private ILogger<HealthCheckController> _logger = null;
        public HealthCheckController(IConfiguration configuration, ILogger<HealthCheckController> logger)
        {
            this._IConfiguration = configuration;
            this._logger = logger;
        }

        /// <summary>
        /// 心跳检测服务
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Check()
        {
            this._logger.LogWarning($"{this._IConfiguration["ip"]}-{this._IConfiguration["port"]}-Health Check!");
            return Ok();//200
        }
    }
}
