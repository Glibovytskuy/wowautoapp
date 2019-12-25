using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace wowautoapp.Extensions.StartupExtensions.RuntimePipelineConfigurations
{
    /// <summary>
    /// Runtime configuration builder for logger
    /// </summary>
    public static partial class RuntimeConfigurationBuilder
    {
        /// <summary>
        /// Uet specified CORS policy
        /// </summary>
        /// <param name="applicationBuilder"></param>
        /// <param name="configuration"></param>
        public static void UseRuntimeCorsBuilder(this IApplicationBuilder applicationBuilder, IConfiguration configuration)
        {
            var policyName = configuration.GetValue<string>("CorsPolicyName");
            applicationBuilder.UseCors(policyName);
        }
    }
}