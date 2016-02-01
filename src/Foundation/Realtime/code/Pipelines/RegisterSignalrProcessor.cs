
using Microsoft.Owin;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.SignalR;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;
using Owin;
using Sitecore.Diagnostics;
using Sitecore.Pipelines;
using VisionsInCode.Foundation.Realtime.Infrastructure;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(VisionsInCode.Foundation.Realtime.Pipelines.RegisterSignalrProcessor))]
namespace VisionsInCode.Foundation.Realtime.Pipelines
{
  using Autofac.Core;
  using VisionsInCode.Foundation.Realtime.Repositories;

  public class RegisterSignalrProcessor
  {
    public void Configuration(IAppBuilder app)
    {
      Log.Info("Startup has started", this);
      GlobalHost.HubPipeline.AddModule(new ErrorHandlingHubPipelineModule());

      ContainerBuilder containerBuilder = new ContainerBuilder();
      containerBuilder.RegisterModule<RealtimeModule>();

      IContainer container = containerBuilder.Build();

      AutofacDependencyResolver resolver = new AutofacDependencyResolver(container);

      app.UseAutofacMiddleware(container);

      app.MapSignalR(new HubConfiguration
      {
        EnableJSONP = true,
        Resolver = resolver
      });


      //AddSignalrInjection(container, resolver);
    }

    private void AddSignalrInjection(IContainer container, AutofacDependencyResolver resolver)
    {
      ContainerBuilder updater = new ContainerBuilder();

      updater.RegisterInstance(resolver.Resolve<IConnectionManager>());
      updater.Update(container);
    }

    public virtual void Process(PipelineArgs args)
    {
      Log.Info("Pipeline RegisterSignalrProcessor called", this);

    }

  }
}