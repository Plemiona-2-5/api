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
        void AddPlayerToTribe(TribePlayer player);
        Tribe SelectedTribe(string tribeName);
    }
}
