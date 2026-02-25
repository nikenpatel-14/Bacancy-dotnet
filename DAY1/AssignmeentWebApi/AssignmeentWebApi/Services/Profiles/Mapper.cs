using AssignmeentWebApi.DTOs;
using AssignmeentWebApi.Repository.Model;
using AutoMapper;

namespace AssignmeentWebApi.Services
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
        }
    }
}
