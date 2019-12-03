using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.EntityFrameworkCore;
using WowAutoApp.Services.Identity.Auth;

namespace wowautoapp.Infrastructure
{
    /// <summary>
    /// Identity server initializer
    /// </summary>
    public interface IIdentityServerInitializer
    {
        /// <summary>
        /// Seed async
        /// </summary>
        /// <returns></returns>
        Task SeedAsync();
    }

    /// <summary>
    /// Identity server initializer
    /// </summary>
    public class IdentityServerInitializer : IIdentityServerInitializer
    {
        private readonly PersistedGrantDbContext _persistedGrantContext;
        private readonly ConfigurationDbContext _configurationContext;

        /// <summary>
        /// constructor Identity server initializer
        /// </summary>
        /// <param name="persistedGrantContext"></param>
        /// <param name="configurationContext"></param>
        public IdentityServerInitializer(PersistedGrantDbContext persistedGrantContext,
            ConfigurationDbContext configurationContext)
        {
            _persistedGrantContext = persistedGrantContext;
            _configurationContext = configurationContext;
        }

        /// <summary>
        /// Seed async
        /// </summary>
        /// <returns></returns>
        virtual public async Task SeedAsync()
        {
            await _persistedGrantContext.Database.MigrateAsync().ConfigureAwait(false);
            await _configurationContext.Database.MigrateAsync().ConfigureAwait(false);

            if (await _configurationContext.Clients.CountAsync() != IdentityServerConfig.GetClients().Count())
            {
                if (await _configurationContext.Clients.AnyAsync())
                    _configurationContext.RemoveRange(_configurationContext.Clients);

                foreach (var client in IdentityServerConfig.GetClients())
                    _configurationContext.Clients.Add(client.ToEntity());

                _configurationContext.SaveChanges();
            }

            if (!await _configurationContext.IdentityResources.AnyAsync())
            {
                foreach (var resource in IdentityServerConfig.GetIdentityResources())
                    _configurationContext.IdentityResources.Add(resource.ToEntity());

                _configurationContext.SaveChanges();
            }

            if (!await _configurationContext.ApiResources.AnyAsync())
            {
                foreach (var resource in IdentityServerConfig.GetApiResources())
                    _configurationContext.ApiResources.Add(resource.ToEntity());

                _configurationContext.SaveChanges();
            }
        }
    }
}