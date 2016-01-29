using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Craig.Extensions;
using Craig.Models.Movies;

namespace Craig
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            CreateContainer();
            CreateMappings();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private static void CreateContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<AutofacModule>();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void CreateMappings()
        {
            AutoMapper.Mapper.CreateMap<Movies.Movie, MovieModel>();
            AutoMapper.Mapper.CreateMap<Movies.Movie, MovieDetailModel>();
            AutoMapper.Mapper.CreateMap<CreateModel, Movies.Movie>()
                .ForMember(movie => movie.Classification, opts => opts.MapFrom(src => src.Classification.GetDescription()));
        }
    }
}
