
namespace WowAutoApp.Services
{
    public interface IVehicleService : IGeneralService<Core.Domain.Vehicle>
    {
        void AddVehicle(Core.Domain.Vehicle vehicle);
    }
}