using System;
using System.Collections.Generic;
using System.Text;
using WowAutoApp.Core.Repo;

namespace WowAutoApp.Services
{
    public class VehicleService : GeneralService<Core.Domain.Vehicle>, IVehicleService
    {
        public VehicleService(IRepository<Core.Domain.Vehicle> profileRepository)
            : base(profileRepository)
        {}

        public void AddVehicle(Core.Domain.Vehicle vehicle)
        {
            if (vehicle == null)
                throw new ArgumentNullException(nameof(vehicle));

            Repository.Insert(vehicle);
        }
    }
}