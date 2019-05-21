using AutoMapper;
using MoviesRentalStore.Dtos;
using MoviesRentalStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesRentalStore.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //From Domain Model to Dto 
            CreateMap<Customer, CustomerDto>();
            CreateMap<Movie, MovieDto>();
            CreateMap<Genre, GenreDto>();
            CreateMap<MembershipType, MembershipTypeDto>();


            //From Dto to Domain Model
            CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore());
            CreateMap<GenreDto, Genre>();
            CreateMap<MembershipTypeDto, MembershipType>();
        }
    }
}