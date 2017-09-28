using AutoMapper;
using Vega.Api.Controllers.Resources;
using Vega.Api.Models;

namespace Vega.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Make, MakeResource>();
            CreateMap<Model, ModelResource>();
            CreateMap<Feature, FeatureResource>();
        }
    }
}
