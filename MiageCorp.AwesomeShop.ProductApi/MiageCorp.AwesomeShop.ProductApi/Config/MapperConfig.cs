using AutoMapper;
using MiageCorp.AwesomeShop.ProductApi.Models;

namespace MiageCorp.AwesomeShop.ProductApi.Config;

public class MapperConfig
{
    public static Mapper InitializeAutoMapper()
    {
        //Provide all the Mapping Configurations
        var config = new MapperConfiguration(cfg =>
        {
            //Configuring the mapping between DTO and Models
            cfg.CreateMap<ProductDTO, Product>();
            cfg.CreateMap<Product, ProductDTO>();
        });
        
        //Create the Mapper
        var mapper = new Mapper(config);
        return mapper;
    }
}