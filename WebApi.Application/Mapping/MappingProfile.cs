using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.CommandQuery.Products.Commands.CreateProducts;
using WebApi.Entity.Dtos;
using WebApi.Entity.Entities;

namespace WebApi.Application.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProductEntity, ProductCommand>().ReverseMap();
            CreateMap<ProductEntity, ProductDto>().ReverseMap();
            CreateMap<byte[], string>().ReverseMap();
        }
    }
}
