using Microsoft.Owin;
using VisionsInCode.Foundation.Realtime.Pipelines;

[assembly: OwinStartup(typeof(RegisterSignalrProcessor))]
namespace VisionsInCode.Foundation.Realtime.Pipelines
{
  using Microsoft.AspNet.SignalR;
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

   
      GlobalHost.HubPipeline.AddModule(new ErrorHandlingHubPipelineModule());

     
      GlobalHost.DependencyResolver.Register(
            typeof(RealtimeHub),
            () =>  new RealtimeHub(new RealtimeVisitorRepository(),new GeoCoordinateRepository(), new HubContextService(), new GeocoderService()));

      app.MapSignalR();

    }

    public virtual void Process(PipelineArgs args)
    {
      Log.Info("Pipeline RegisterSignalrProcessor called", this);

    }

  }
}