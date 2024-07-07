using AutoMapper;
using WebGraph.Dto;
using WebGraph.Models;

namespace WebGraph.Mapper
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductGroup, ProductGroupDto>().ReverseMap();
            CreateMap<Storage, StorageDto>().ReverseMap();
        }
    }
}
