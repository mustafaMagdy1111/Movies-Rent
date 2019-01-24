using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Movies_Rent.Controllers;
using Movies_Rent.Dtos;
using Movies_Rent.Models;

namespace Movies_Rent.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<customer, CustomerDTo>();
            Mapper.CreateMap<CustomerDTo, customer>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>();
            Mapper.CreateMap<MemberShipType, MemberShipTypeDto>();
            Mapper.CreateMap<MemberShipTypeDto, MemberShipType>();
            Mapper.CreateMap<Genre, GenreDto>();
            Mapper.CreateMap<GenreDto, Genre>();



            // Dto to Domain
            Mapper.CreateMap<CustomerDTo, customer>()
                .ForMember(c => c.id, opt => opt.Ignore());

            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(c => c.ID, opt => opt.Ignore());
        }
    }
}