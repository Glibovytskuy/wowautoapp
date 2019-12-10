using System;
using WowAutoApp.Core.Repo;

namespace WowAutoApp.Services.Buisness
{
    public class BuisnessService : GeneralService<Core.Domain.Buisness>, IBuisnessService
    {
        public BuisnessService(IRepository<Core.Domain.Buisness> profileRepository)
            : base(profileRepository)
        { }

        public void AddBuisness(Core.Domain.Buisness vehicle)
        {
            if (vehicle == null)
                throw new ArgumentNullException(nameof(vehicle));

            Repository.Insert(vehicle);
        }
    }
}