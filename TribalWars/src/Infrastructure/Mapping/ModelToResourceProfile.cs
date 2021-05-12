using ApplicationCore.Entities;
using AutoMapper;
using Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Building, BuildingViewModel>();
            CreateMap<BuildingRequiredBuilding, RequiredBuildingViewModel>();
        }
    }
}
