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
            //From Model to Dto 
            CreateMap<Customer, CustomerDto>();
            CreateMap<Movie, MovieDto>();
            CreateMap<Genre, GenreDto>();


            //From Dto to Model
            CreateMap<CustomerDto, Customer>();
            CreateMap<MovieDto, Movie>();
            CreateMap<GenreDto, Genre>();
        }
    }
}