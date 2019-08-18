using AutoMapper;
using MoviesRentalStore.App_Start;
using MoviesRentalStore.Dtos;
using MoviesRentalStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MoviesRentalStore
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static MapperConfiguration _config;

        protected void Application_Start()
        {
            //Mapper.Initialize(c => c.AddProfile<MappingProfile>());
            _config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
                //cfg.CreateMap<Customer, CustomerDto>();
                //cfg.CreateMap<Genre, GenreDto>();
                //cfg.CreateMap<MembershipType, MembershipTypeDto>();
                //cfg.CreateMap<Movie, MovieDto>();
                //cfg.CreateMap<Rental, NewRentalDto>();
            });
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
