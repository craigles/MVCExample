using Autofac;
using Autofac.Integration.Mvc;
using ConfigInjector.Configuration;
using Craig.Settings;
using Movies;

namespace Craig
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<MovieRepository>().As<IMovieRepository>();
            builder.RegisterType<PageSize>();

            ConfigurationConfigurator.RegisterConfigurationSettings()
                         .FromAssemblies(typeof(PageSize).Assembly)
                         .RegisterWithContainer(configSetting => builder.RegisterInstance(configSetting)
                             .AsSelf()
                             .SingleInstance())
                         .AllowConfigurationEntriesThatDoNotHaveSettingsClasses(true)
                         .DoYourThing();
        }
    }
}