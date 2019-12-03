﻿using System.Threading.Tasks;
using IdentityModel;
using IdentityModel.AspNetCore.OAuth2Introspection;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using WowAutoApp.Core.Consts;
using WowAutoApp.Services.Identity.Auth;
using wowautoapp.Infrastructure;

namespace wowautoapp.Extentions.StartupExtensions
{
    /// <summary>
    ///     Dependency injection for jwt configurator
    /// </summary>
    public static partial class DependencyСonfigurator
    {
        /// <summary>
        ///     Add jwt configuration
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddAuthenticationConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = configuration.GetSection("JwtIssuer")["Audience"];
                    options.SupportedTokens = SupportedTokens.Jwt;
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false; // Note: Set to true in production
                    options.ApiName = IdentityServerConfig.ApiName;
                    options.ClaimsIssuer = configuration.GetSection("JwtIssuer")["Issuer"];
                    options.TokenRetriever = request =>
                    {
                        var fromQuery = TokenRetrieval.FromQueryString();
                        var fromHeader = TokenRetrieval.FromAuthorizationHeader();

                        return fromHeader(request) ?? fromQuery(request);
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                                context.Response.Headers.Add("Token-Expired", "true");

                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddDataProtection();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("SystemAdminAccess", policy => policy.RequireRole(Consts.SystemAdmin));
                options.AddPolicy("ApiUser", policy => policy.RequireClaim(JwtClaimTypes.Role, JwtClaims.ApiAccess));
            });

            services.AddTransient<IIdentityServerInitializer, IdentityServerInitializer>();
        }
    }
}