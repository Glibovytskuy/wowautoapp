using System;
namespace WowAutoApp.Services
{
    public interface IBuisnessService : IGeneralService<Core.Domain.Buisness>
    {
        void AddBuisness(Core.Domain.Buisness vehicle);
    }
}
