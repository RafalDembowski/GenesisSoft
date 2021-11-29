using Application.Products;
using Application.Users;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.General
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegisterDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<ProductCreateDto, Product>();
            CreateMap<Product, ProductListDto>()
                .ForMember(p => p.UpdatedBy, o => o.MapFrom(s => s.UpdatedBy.Name))
                .ForMember(p => p.CreatedBy, o => o.MapFrom(s => s.CreatedBy.Name))
                .ForMember(p => p.ProducerName, o => o.MapFrom(s => s.Producer.Name))
                .ForMember(p => p.CategoryName, o => o.MapFrom(s => s.Category.Name));
        }
    }
}
