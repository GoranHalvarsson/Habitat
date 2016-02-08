using Microsoft.Owin;
using VisionsInCode.Foundation.Realtime.Pipelines;

[assembly: OwinStartup(typeof(RegisterSignalrProcessor))]
namespace VisionsInCode.Foundation.Realtime.Pipelines
{
  using Autofac;
  using Autofac.Integration.SignalR;
  using Microsoft.AspNet.SignalR;
  using Microsoft.AspNet.SignalR.Infrastructure;
  using Owin;
  using Sitecore.Diagnostics;
  using Sitecore.Pipelines;
  using VisionsInCode.Foundation.Realtime.Infrastructure;
  using VisionsInCode.Foundation.Realtime.Repositories;

  public class RegisterSignalrProcessor
  {
    public void Configuration(IAppBuilder app)
    {
      Log.Info("Startup has started", this);

      //Container container = new Container();
      //container.RegisterSingleton<IHubContextService, HubContextService>();
      //container.RegisterSingleton<IGeoCoordinateRepository, GeoCoordinateRepository>();
      //container.RegisterSingleton<IRealtimeVisitorRepository, RealtimeVisitorRepository>();


      GlobalHost.HubPipeline.AddModule(new ErrorHandlingHubPipelineModule());

     
      GlobalHost.DependencyResolver.Register(
            typeof(RealtimeHub),
            () =>  new RealtimeHub(new RealtimeVisitorRepository(),new GeoCoordinateRepository(), new HubContextService(), new GeocoderService()));

      app.MapSignalR();

      //ContainerBuilder containerBuilder = new ContainerBuilder();
      //containerBuilder.RegisterModule<RealtimeModule>();

      //IContainer container = containerBuilder.Build();

      //HubConfiguration config = new HubConfiguration
      //{
      //  EnableJSONP = true,
      //  Resolver = new AutofacDependencyResolver(container)
      //};

      //app.UseAutofacMiddleware(container);
      //app.MapSignalR(config);

    
      //ConfigureSignalR(app, config);

    }

    private void AddSignalrInjection(IContainer container, AutofacDependencyResolver resolver)
    {
      ContainerBuilder updater = new ContainerBuilder();

      updater.RegisterInstance(resolver.Resolve<IConnectionManager>());
      updater.Update(container);
    }

    public static void ConfigureSignalR(IAppBuilder app, HubConfiguration config)
    {
      app.MapSignalR(config);
    }
    public virtual void Process(PipelineArgs args)
    {
      Log.Info("Pipeline RegisterSignalrProcessor called", this);

    }

  }
}