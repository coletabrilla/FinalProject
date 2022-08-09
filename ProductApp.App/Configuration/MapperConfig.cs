using AutoMapper;
using FinalProject.DataModel;
using ProductApp.App.Models;

namespace ProductApp.App.Configuration
{
    public class MapperConfig : Profile
    {

        public MapperConfig()
        {
            CreateMap<Product, ProductVM>().ReverseMap();
        }
    }
}
