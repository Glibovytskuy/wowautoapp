using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using WowAutoApp.Services.Utilities;

namespace wowautoapp.Extensions.StartupExtensions.RuntimePipelineConfigurations
{
    /// <summary>
    /// Runtime configuration builder
    /// </summary>
    public static partial class RuntimeConfigurationBuilder
    {
        /// <summary>
        /// Use exception handler
        /// </summary>
        /// <param name="applicationBuilder"></param>
        public static void UseRuntimeExceptionHandler(this IApplicationBuilder applicationBuilder)
        {
            //TODO: Implement more advanced Error Handling
            applicationBuilder.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                    // TODO: This is not very secure. Need to explicitly specify the allowed domains.
                    // TODO: Extract those domains to application configuration
                    // TODO: Research, this probably be removed since it is overriding the CORS policy defined in startup. Not secure.
                    context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                    var error = context.Features.Get<IExceptionHandlerFeature>();
                    if (error != null)
                    {
                        context.Response.AddApplicationError(error.Error.Message);
                        await context.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
                    }
                });
            });
        }
    }
}
