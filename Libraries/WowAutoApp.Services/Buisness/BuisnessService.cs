using System;
using WowAutoApp.Core.Repo;

namespace WowAutoApp.Services.Buisness
{
    public class BuisnessService : GeneralService<Core.Domain.Buisness>, IBuisnessService
    {
        

        public BuisnessService(IRepository<Core.Domain.Buisness> profileRepository
           ) : base(profileRepository)
        {}

        public void AddBuisness(Core.Domain.Buisness buisness)
        {
            if (buisness == null)
                throw new ArgumentNullException(nameof(buisness));

            Repository.Insert(buisness);
        }
    }
}