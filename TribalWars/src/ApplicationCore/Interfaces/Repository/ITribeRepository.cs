using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Repository
{
    public interface ITribeRepository
    {
        int CreateTribe(Tribe tribe);
        Task AddPlayerToTribe(TribePlayer player);
        Task<Tribe> SelectedTribe(string tribeName);
    }
}
