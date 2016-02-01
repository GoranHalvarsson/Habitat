

namespace VisionsInCode.Foundation.Realtime.Infrastructure
{
  using System.Reflection;
  using Autofac;
  using Autofac.Integration.SignalR;
  using Microsoft.AspNet.SignalR.Hubs;
  using VisionsInCode.Foundation.Realtime.Repositories;

  public class RealtimeModule : Autofac.Module
  {
    protected override void Load(ContainerBuilder containerBuilder)
    {
      base.Load(containerBuilder);

      containerBuilder.RegisterType<RealtimeHub>().ExternallyOwned();

      //containerBuilder.RegisterHubs(Assembly.GetExecutingAssembly())
      //          .PropertiesAutowired();

      //containerBuilder.RegisterType<HubLifetimeScopeManager>().SingleInstance();
      //containerBuilder.RegisterType<HubActivator>().As<IHubActivator>().SingleInstance();

      ////Register SignalR hubs (must be marked ExternallyOwned so that instances will be destroyed by SignalR rather than Autofac)
      //containerBuilder.RegisterAssemblyTypes(typeof(VisionsInCode.Foundation.Realtime.Startup).Assembly)
      //  .Where(t => !t.IsAbstract && t.IsClass && t.IsAssignableTo<IHub>())
      //  .InstancePerDependency()
      //  .ExternallyOwned();


      containerBuilder.RegisterType<HubContextService>()
        .As<IHubContextService>()
        .InstancePerLifetimeScope();


      containerBuilder.RegisterType<GeoCoordinateRepository>()
        .As<IGeoCoordinateRepository>()
        .InstancePerLifetimeScope();

      containerBuilder.RegisterType<RealtimeVisitorRepository>()
        .As<IRealtimeVisitorRepository>()
        .InstancePerLifetimeScope();

    }
  }
}