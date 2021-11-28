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
            CreateMap<ProductDto, Product>();
            CreateMap<User, UserDto>();
        }
    }
}
