using Microsoft.Extensions.Logging;
using Volo.Abp.DependencyInjection;

namespace MyCmsPlugin
{
    public class MyCmsPluginService : ITransientDependency
    {
        private readonly ILogger<MyCmsPluginService> _logger;

        public MyCmsPluginService(ILogger<MyCmsPluginService> logger)
        {
            _logger = logger;
        }


        public void Initialize()
        {
            _logger.LogInformation("MyCmsPluginService has been initialized");
        }
    }
}
