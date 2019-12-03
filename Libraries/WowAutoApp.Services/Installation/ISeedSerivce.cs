using System;

namespace WowAutoApp.Services.Installation
{
    public interface ISeedSerivce
    {
        void InstallData(IServiceProvider services);
    }
}