using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EBiograf.Web.Api.Models;

namespace EBiograf.Web.Api.Helper
{
    //The automapper profile contains the mapping configuration used by the application, AutoMapper is a package available on Nuget that enables automatic mapping of one type of classes to another.
    //In this example we're using it to map between User entities and a few different model types - UserModel, RegisterModel and UpdateModel.
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<User, UserModel>();
            CreateMap<RegisterModelUser, User>();
            CreateMap<UpdateModel, User>();

        }
    }
}
